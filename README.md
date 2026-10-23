# Enimizer

Note you need to put a 1.0 jp rom in BasePatchGenerator\bin\Debug|Release named zelda.sfc in order to build the project if you want to help out with development.

## EnemizerCLI.Core (used by alttpr.com)

`EnemizerCLI.Core` targets .NET 10 and publishes as a self-contained single
file, so the host needs no .NET runtime, libicu or libunwind.

    tools/publish.sh                 # dist/<rid>.tar.gz for linux-x64, linux-arm64, osx-x64, osx-arm64
    tools/publish.sh linux-x64       # just one runtime

Pushing a `v*` tag runs `.github/workflows/release.yml`, which attaches the
tarballs to a GitHub release.

### Checking output parity

`tools/parity/parity.py` runs two builds over a few hundred seed × option
cases (the same options alttpr writes) and fails if any output patch differs.
Compare against the build alttpr.com runs today:

    curl -L https://github.com/cassidoxa/Enimizer/releases/download/linux-build-0.1.0/linux-x64.tar.gz | tar xz -C old
    tools/publish.sh linux-x64
    tools/parity/parity.py --old old --new dist/linux-x64 \
        --base <z3randomizer patch>.json --rom <JP 1.0 ROM> \
        --randomizer-patches <alttpr seed JSON files or dirs> \
        --env LD_LIBRARY_PATH=<dir with libicu70>   # the old .NET Core 2.0 build needs an ICU it recognises

CI (`.github/workflows/ci.yml`) runs this on every PR with a stand-in ROM
(zeros plus the title header), which covers boss, pot, health and damage
options; dungeon enemy shuffle needs real room data and throws identically in
both builds there. Set the `ROM_URL` repository secret to a private URL for
the JP 1.0 ROM and a second job runs the same cases against the real ROM.

Never commit a ROM to this repository.
