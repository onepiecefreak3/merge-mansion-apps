using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using Game.Logic;
using GameLogic;
using GameLogic.Area;
using GameLogic.Config;
using merge_mansion_dumper.Dumper;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Generated;
using Metaplay.Unity;
using Metaplay.Unity.ConnectionStates;
using UnityEngine;

namespace merge_mansion_dumper
{
    class Options
    {
        [Option('m', "mode", Required = true, HelpText = "Set the mode to dump data with\n  1: all\n  2: merge chains\n  3: areas\n  4: events\n  5: dialogs")]
        public int Mode { get; set; }

        [Option('c', "config", Required = false, HelpText = "Sets the path to the config archive to use. This will not download any other data archives or localizations!")]
        public string ConfigArchivePath { get; set; }
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
        public static bool VersionBumped { get; private set; }

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
            var isSetup = SetupSystem(o.ConfigArchivePath);
            if (!isSetup)
                return;

            // Dump data to files
            Dump(o);

            Console.WriteLine("Done.");
        }

        private static bool SetupSystem(string? configArchivePath)
        {
            if (!string.IsNullOrEmpty(configArchivePath))
            {
                // Setup fixed data without unnecessary internal systems
                MetaplayCore.Initialize();
                
                var archive = ConfigArchive.FromBytes(FileUtil.ReadAllBytes(configArchivePath));
                var gameConfig = (SharedGameConfig)GameConfigFactory.Instance.ImportSharedGameConfig(PatchedConfigArchive.WithNoPatches(archive));

                ClientGlobal.SharedGameConfig = gameConfig;

                return true;
            }

            Console.WriteLine("Setup game session...");

            TypeSerializer.Tracer.Instance.Register(AreaId.FromString("AntiqueDealer"));

            try
            {
            Initialize:
                MetaplayCore.Initialize();

                var client = new MetaplayClient();

                MetaplaySDK.Connection.Connect();

                while (ClientGlobal.SharedGameConfig == null)
                {
                    client.Update();

                    if (MetaplaySDK.Connection.State.Status != ConnectionStatus.Error)
                        continue;

                    if (MetaplaySDK.Connection.State is TerminalError.LogicVersionMismatch me)
                    {
                        Console.WriteLine($"[!] There is a new game version available: {me.ServerAcceptedVersions.MinVersion}");

                        VersionBumped = true;

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
            catch (Exception e)
            {
                Console.WriteLine("An error occurred setting up the session. Did the data models change?");
#if DEBUG
                Console.WriteLine($"Aborted ({e.Message})");
#endif

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
