using CommandLine;
using EnemizerLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace EnemizerCLI.Core
{
    class Program
    {
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<CommandLineOptions>(args)
                .MapResult(options =>
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    MakeEnemizerPatch(options);
                    stopwatch.Stop();
                    Console.WriteLine($"Seed generated in: {stopwatch.Elapsed}");
                    return 0;
                },
                errors => errors.IsHelp() || errors.IsVersion() ? 0 : 1);
        }

        static void MakeEnemizerPatch(CommandLineOptions options)
        {
            var basePatchJson = File.ReadAllText(options.BasePatchJsonFilename);
            var randoPatchJson = File.ReadAllText(options.RandomizerPatchJsonFilename);
            var optionFlags = JsonConvert.DeserializeObject<OptionFlags>(File.ReadAllText(options.EnemizerOptionsJsonFilename));

            RandomizerPatch randoPatch = new RandomizerPatch(basePatchJson, randoPatchJson);


            // load base rom
            FileStream fs = new FileStream(options.BaseRomFilename, FileMode.Open, FileAccess.Read);
            byte[] rom_data = new byte[fs.Length];
            fs.Read(rom_data, 0, (int)fs.Length);
            fs.Close();

            Array.Resize(ref rom_data, 2 * 1024 * 1024);

            randoPatch.PatchRom(ref rom_data);

#if DEBUG
            FileStream testout = new FileStream("rando output.sfc", FileMode.OpenOrCreate, FileAccess.Write);
            testout.Write(rom_data, 0, rom_data.Length);
            testout.Close();
#endif

            RomData romData = new RomData(rom_data);

            if (romData.IsEnemizerRom)
            {
                throw new Exception("How is the base rom an enemizer rom?");
            }

            Random rand = new Random();

            int seed;
            if (String.IsNullOrEmpty(options.SeedNumber))
            {
                seed = rand.Next(0, 999999999);
            }
            else
            {
                // TODO: add validation to the textbox so it can't be anything but a number
                if (!int.TryParse(options.SeedNumber, out seed))
                {
                    throw new Exception("Invalid Seed Number entered. Please enter an integer value.");
                }
                if (seed < 0)
                {
                    throw new Exception("Please enter a positive Seed Number.");
                }
            }

            // TODO: add spoiler
            var enemPatch = GenerateSeed(seed, rom_data, optionFlags);

            var patchJson = JsonConvert.SerializeObject(enemPatch);

            File.WriteAllText(options.OutputPatchJsonFilename, patchJson);

            Console.WriteLine($"Generated file {options.OutputPatchJsonFilename}");
        }

        static List<PatchObject> GenerateSeed(int seed, byte[] rom_data, OptionFlags optionFlags)
        {
            RomData romData = new RomData(rom_data);
            Randomization randomize = new Randomization();
            RomData randomizedRom = randomize.MakeRandomization("", seed, optionFlags, romData, "");

            return randomizedRom.GeneratePatch();
        }

    }
}
