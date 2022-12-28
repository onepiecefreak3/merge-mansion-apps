using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using merge_mansion_cli.Dumper;
using Metaplay;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Unity;

namespace merge_mansion_cli
{
    class Options
    {
        [Option('m', "mode", Required = true, HelpText = "Set the mode to dump data with\n  1: all\n  2: merge chains\n  3: areas\n  4: events\n  5: dialogs")]
        public int Mode { get; set; }
    }

    public enum Mode
    {
        All = 1,
        MergeChains,
        Areas,
        Events,
        Dialogs
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var parser = new Parser(parserSettings => parserSettings.AutoHelp = true);

            var parsedResult = parser.ParseArguments<Options>(args);

            await parsedResult
                .WithNotParsed(errors => DisplayHelp(parsedResult, errors))
                .WithParsedAsync(Execute);
        }

        private static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errors)
        {
            var helpText = HelpText.AutoBuild(result, h =>
            {
                h.AdditionalNewLineAfterOption = false;
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);

            Console.WriteLine(helpText);
        }

        private static async Task Execute(Options o)
        {
            await SetupSystem();

            Console.Write("Dump data... ");

            switch ((Mode)o.Mode)
            {
                case Mode.All:
                    DumpHelper.DumpAll();
                    break;

                case Mode.MergeChains:
                    DumpHelper.DumpMergeChains();
                    break;

                case Mode.Areas:
                    DumpHelper.DumpAreas();
                    break;

                case Mode.Events:
                    DumpHelper.DumpEvents();
                    break;

                case Mode.Dialogs:
                    DumpHelper.DumpDialogs();
                    break;
            }

            Console.WriteLine("Ok");
        }

        private static async Task SetupSystem()
        {
            Console.Write("Setup game session... ");

            MetaplayCore.Initialize();

            var client = new MetaplayClient();

            MetaplaySDK.Connection.Connect();

            while (ClientGlobal.SharedGameConfig == null)
            {
                client.Update();
                await Task.Delay(TimeSpan.FromMilliseconds(300));
            }

            Console.WriteLine("Ok");
        }
    }
}
