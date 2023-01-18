// See https://aka.ms/new-console-template for more information

using CommandLine;
using FMTools.Randomizer;
using FMTools.Runner;
using FMTools.Utility;
using System.Diagnostics;
using System.IO;

Parser.Default.ParseArguments<RunnerOptions>(args)
                   .WithParsed<RunnerOptions>(o => {
                        var opt = Newtonsoft.Json.JsonConvert.DeserializeObject<Options>(File.ReadAllText(o.OptionFile));

                       Static.SetOptions(opt);
                       Static.InitCharTable();
                       DataScrambler fileHandler = new DataScrambler(opt.Seed ?? Random.Shared.Next());

                       var isoLoader = new IsoLoader();
                       isoLoader.LoadIso(Static.IsoPath);

                       

                        fileHandler.PerformScrambling(0, 0, 0, 0, 0, 0, opt.MinDropRate, opt.MaxDropRate);

                       ImagePatcher patcher = new ImagePatcher(Static.IsoPath);
                       patcher.PatchImage();

                       Console.ReadKey(true);
                       /*(int)txt_minAtk.Value, (int)txt_maxAtk.Value,
                           (int)txt_minDef.Value, (int)txt_maxDef.Value, (int)txt_minCost.Value,
                           (int)txt_maxCost.Value, (int)txt_minDropRate.Value, (int)txt_maxDropRate.Value
                       */
                   });