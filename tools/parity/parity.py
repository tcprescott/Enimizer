#!/usr/bin/env python3
"""Compare the patches two EnemizerCLI.Core builds emit for the same inputs.

Runs both builds over a deterministic set of (randomizer patch x enemizer
options x enemizer seed) cases, mirroring the options alttpr writes in
app/Enemizer.php, and fails if any output patch differs byte for byte.

    parity.py --old DIR --new DIR --base BASE.json --rom ROM.sfc \
        --randomizer-patches DIR_OR_FILE... [--cases 300] [--jobs 4]

--rom may be the real JP 1.0 ROM, or a synthetic stand-in made with
--make-synthetic-rom PATH (no game data, so it can run in CI).

fixtures/ holds the z3randomizer base patch production uses (79bbb4ad) and a
few alttpr seed write logs. They are randomizer output, not ROM data.
"""
import argparse
import concurrent.futures
import hashlib
import json
import os
import random
import subprocess
import sys
import tempfile

BOSSES = ["Armos", "Lanmola", "Moldorm", "Helmasaur", "Arrghus", "Mothula",
          "Blind", "Kholdstare", "Vitreous", "Trinexx"]
BOSS_SLOTS = ["EasternPalace", "DesertPalace", "TowerOfHera", "PalaceOfDarkness",
              "SwampPalace", "SkullWoods", "ThievesTown", "IcePalace", "MiseryMire",
              "TurtleRock", "GanonsTower1", "GanonsTower2", "GanonsTower3"]


def options_for(rng, enemy_shuffle, enemy_health, enemy_damage, boss_shuffle, pot_shuffle):
    """Same keys and mapping as alttpr's Enemizer::writeOptionsFile()."""
    o = {
        "RandomizeEnemies": enemy_shuffle != "none",
        "RandomizeEnemiesType": 3,
        "RandomizeBushEnemyChance": enemy_shuffle == "random",
        "RandomizeEnemyHealthRange": enemy_health != "default",
        "RandomizeEnemyHealthType": {"easy": 0, "default": 1, "hard": 2, "expert": 3}[enemy_health],
        "OHKO": False,
        "RandomizeEnemyDamage": enemy_damage != "default",
        "AllowEnemyZeroDamage": True,
        "ShuffleEnemyDamageGroups": enemy_damage in ("shuffled", "random"),
        "EnemyDamageChaosMode": enemy_damage == "random",
        "EasyModeEscape": False,
        "EnemiesAbsorbable": False,
        "AbsorbableSpawnRate": 10,
        "AbsorbableTypes": {k: True for k in [
            "FullMagic", "SmallMagic", "Bomb_1", "BlueRupee", "Heart", "BigKey", "Key",
            "Fairy", "Arrow_10", "Arrow_5", "Bomb_8", "Bomb_4", "GreenRupee", "RedRupee"]},
        "BossMadness": False,
        "RandomizeBosses": boss_shuffle != "none",
        "RandomizeBossesType": {"none": 0, "simple": 0, "full": 1, "random": 2}[boss_shuffle],
        "RandomizeBossHealth": False,
        "RandomizeBossHealthMinAmount": 0,
        "RandomizeBossHealthMaxAmount": 300,
        "RandomizeBossDamage": False,
        "RandomizeBossDamageMinAmount": 0,
        "RandomizeBossDamageMaxAmount": 200,
        "RandomizeBossBehavior": False,
        "RandomizeDungeonPalettes": False,
        "SetBlackoutMode": False,
        "RandomizeOverworldPalettes": False,
        "RandomizeSpritePalettes": False,
        "SetAdvancedSpritePalettes": False,
        "PukeMode": False,
        "NegativeMode": False,
        "GrayscaleMode": False,
        "GenerateSpoilers": False,
        "RandomizeLinkSpritePalette": False,
        "RandomizePots": pot_shuffle == "on",
        "ShuffleMusic": False,
        "BootlegMagic": True,
        "CustomBosses": False,
        "AndyMode": False,
        "HeartBeepSpeed": 2,
        "AlternateGfx": False,
        "ShieldGraphics": "shield_gfx/normal.gfx",
        "SwordGraphics": "sword_gfx/normal.gfx",
        "BeeMizer": False,
        "BeesLevel": 3,
        "RandomizeTileTrapPattern": enemy_shuffle == "random",
        "RandomizeTileTrapFloorTile": False,
        "AllowKillableThief": bool(rng.randint(0, 1)) if enemy_shuffle == "random" else enemy_shuffle != "none",
        "RandomizeSpriteOnHit": False,
        "DebugMode": False,
        "DebugForceEnemy": True,
        "DebugForceEnemyId": 196,
        "DebugForceBoss": False,
        "DebugForceBossId": 4,
        "DebugOpenShutterDoors": False,
        "DebugForceEnemyDamageZero": True,
        "DebugShowRoomIdInRupeeCounter": True,
        "UseManualBosses": boss_shuffle != "none",
    }
    if boss_shuffle != "none":
        bosses = {slot: rng.choice(BOSSES) for slot in BOSS_SLOTS}
        bosses.update({"AgahnimsTower": "Agahnim", "GanonsTower4": "Agahnim2", "Ganon": "Ganon"})
        o["ManualBosses"] = bosses
    return o


def make_cases(n, randomizer_patches, rng):
    cases = []
    for i in range(n):
        enemy_shuffle = rng.choice(["none", "shuffled", "random"])
        boss_shuffle = rng.choice(["none", "simple", "full", "random"])
        pot_shuffle = rng.choice(["off", "on"])
        # alttpr only runs the Enemizer when something is enemized; keep the
        # all-default case anyway since the binary must still match there.
        cases.append({
            "id": i,
            "randomizer": randomizer_patches[i % len(randomizer_patches)],
            "seed": rng.randint(1, 999999999),
            "options": options_for(rng, enemy_shuffle,
                                   rng.choice(["default", "easy", "hard", "expert"]),
                                   rng.choice(["default", "shuffled", "random"]),
                                   boss_shuffle, pot_shuffle),
        })
    return cases


def run(build, case, args, workdir):
    opts = os.path.join(workdir, f"{case['id']}.options.json")
    out = os.path.join(workdir, f"{case['id']}.{os.path.basename(build)}.json")
    with open(opts, "w") as f:
        json.dump(case["options"], f)
    try:
        proc = subprocess.run(
            [os.path.join(build, "EnemizerCLI.Core"), "--rom", args.rom, "--seed", str(case["seed"]),
             "--base", args.base, "--randomizer", case["randomizer"], "--enemizer", opts, "--output", out],
            cwd=build, capture_output=True, env={**os.environ, **args.env}, timeout=args.timeout)
    except subprocess.TimeoutExpired:
        return "timeout", None, ""
    data = None
    if proc.returncode == 0 and os.path.exists(out):
        with open(out, "rb") as f:
            data = f.read()
    return proc.returncode, data, proc.stderr.decode(errors="replace")[-400:]


def compare(case, args, workdir):
    old = run(args.old, case, args, workdir)
    new = run(args.new, case, args, workdir)
    ok = old[0] == new[0] and old[1] == new[1]
    return case, ok, old, new


def write_randomizer_patches(paths, workdir):
    """Accept alttpr seed JSON ({"writes": [...]}) or a bare write list."""
    result = []
    for p in paths:
        files = [os.path.join(p, f) for f in sorted(os.listdir(p)) if f.endswith(".json")] if os.path.isdir(p) else [p]
        for f in files:
            with open(f) as fh:
                data = json.load(fh)
            writes = data["writes"] if isinstance(data, dict) else data
            dest = os.path.join(workdir, "rando-" + hashlib.sha1(f.encode()).hexdigest()[:12] + ".json")
            with open(dest, "w") as fh:
                json.dump(writes, fh)
            result.append(dest)
    return result


def make_synthetic_rom(path):
    """A 1 MB ROM of zeros with only the internal title set.

    The Enemizer refuses input that does not look like a randomizer ROM, so
    the title is required. There is no game data, so dungeon enemy shuffle
    usually throws ("water room without any water sprites"); both builds must
    still throw identically. Boss, pot, health and damage options produce
    real patches.
    """
    rom = bytearray(1024 * 1024)
    rom[0x7FC0:0x7FCF] = b"ZELDANODENSETSU"
    with open(path, "wb") as f:
        f.write(rom)


def main():
    ap = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    ap.add_argument("--old")
    ap.add_argument("--new")
    ap.add_argument("--base")
    ap.add_argument("--rom")
    ap.add_argument("--randomizer-patches", nargs="*", default=[], help="alttpr seed JSON files or directories of them")
    ap.add_argument("--cases", type=int, default=300)
    ap.add_argument("--jobs", type=int, default=os.cpu_count())
    ap.add_argument("--timeout", type=int, default=60, help="seconds per run before it counts as a hang")
    ap.add_argument("--rng-seed", type=int, default=20261022)
    ap.add_argument("--env", action="append", default=[], metavar="KEY=VALUE",
                    help="extra environment for running the builds (e.g. LD_LIBRARY_PATH=<libicu70> for the old .NET Core 2.0 build)")
    ap.add_argument("--make-synthetic-rom", metavar="PATH")
    args = ap.parse_args()

    if args.make_synthetic_rom:
        make_synthetic_rom(args.make_synthetic_rom)
        return 0
    for req in ("old", "new", "base", "rom"):
        if not getattr(args, req):
            ap.error(f"--{req} is required")
    args.old, args.new = os.path.abspath(args.old), os.path.abspath(args.new)
    args.rom, args.base = os.path.abspath(args.rom), os.path.abspath(args.base)
    args.env = dict(kv.split("=", 1) for kv in args.env)

    with tempfile.TemporaryDirectory() as workdir:
        patches = write_randomizer_patches(args.randomizer_patches, workdir)
        if not patches:
            empty = os.path.join(workdir, "rando-empty.json")
            with open(empty, "w") as fh:
                fh.write("[]")
            patches = [empty]
        cases = make_cases(args.cases, patches, random.Random(args.rng_seed))
        failures = errors_both = 0
        distinct = set()
        with concurrent.futures.ThreadPoolExecutor(args.jobs) as pool:
            for case, ok, old, new in pool.map(lambda c: compare(c, args, workdir), cases):
                if old[1] is not None:
                    distinct.add(hashlib.sha1(old[1]).digest())
                if old[0] != 0 and ok:
                    errors_both += 1
                if not ok:
                    failures += 1
                    print(f"MISMATCH case {case['id']} seed {case['seed']}: "
                          f"old exit {old[0]} ({len(old[1] or b'')} bytes), new exit {new[0]} ({len(new[1] or b'')} bytes)")
                    for label, r in (("old", old), ("new", new)):
                        if r[0] != 0:
                            print(f"  {label} stderr: {r[2]}")
        print(f"{len(cases)} cases, {len(cases) - failures} identical "
              f"({errors_both} of those failed identically in both builds), {failures} mismatched; "
              f"{len(distinct)} distinct patches")
        return 1 if failures else 0


if __name__ == "__main__":
    sys.exit(main())
