using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using merge_mansion_cli.Dumper;
using Metaplay;
using Metaplay.Game.Logic;
using Metaplay.GameLogic.Story;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Unity;
using Metaplay.Metaplay.Unity.ConnectionStates;
using Metaplay.UnityEngine;

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
            // Setup system
            var isSetup = SetupSystem();
            if (!isSetup)
                return;

            // Dump data to files
            Dump(o);

            Console.WriteLine("Done.");
        }

        private static bool SetupSystem()
        {
            Console.WriteLine("Setup game session...");

            try
            {
            Initialize:
                MetaplayCore.Initialize();

                var client = new MetaplayClient();

                MetaplaySDK.Connection.Connect();

                while (ClientGlobal.SharedGameConfig == null)
                {
                    client.Update();

                    if (MetaplaySDK.Connection.State.Status == ConnectionStatus.Error)
                    {
                        if (MetaplaySDK.Connection.State is TerminalError.LogicVersionMismatch me)
                        {
                            GlobalOptions.MinVersion = me.ServerAcceptedVersions.MinVersion;
                            GlobalOptions.MaxVersion = me.ServerAcceptedVersions.MaxVersion;
                            Application.Version = $"{me.ServerAcceptedVersions.MinVersion}";

                            MetaplayCore.Reset();

                            goto Initialize;
                        }

                        if (MetaplaySDK.Connection.State is TerminalError.InMaintenance maintenance)
                        {
                            Console.WriteLine("Servers are in maintenance.");
                            return false;
                        }

                        Console.WriteLine($"Connection Error ({MetaplaySDK.Connection.State.GetType().Name})");
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Aborted ({e.Message})");
                return false;
            }

            return true;
        }

        private static void Dump(Options o)
        {
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
        }
    }
}
