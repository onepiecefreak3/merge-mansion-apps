using System;
using System.IO;
using System.Threading.Tasks;
using merge_mansion_cli.Dumper;
using Metaplay;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Unity;

namespace merge_mansion_cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await SetupSystem();

            new ChainDumper(true).WriteJson(@"chain_item_odds.json", ClientGlobal.SharedGameConfig);
            new AreaDumper().WriteJson(@"areas.json", ClientGlobal.SharedGameConfig);
            new EventDumper().WriteJson(@"events.json", ClientGlobal.SharedGameConfig);
            new DialogDumper().ExportImages(@"dialogs", ClientGlobal.SharedGameConfig);
        }

        private static async Task SetupSystem()
        {
            MetaplayCore.Initialize();

            var client = new MetaplayClient();

            MetaplaySDK.Connection.Connect();

            while (ClientGlobal.SharedGameConfig == null)
            {
                client.Update();
                await Task.Delay(TimeSpan.FromMilliseconds(500));
            }
        }

        private static PatchedConfigArchive GetConfigArchive()
        {
            var path = @"76F659E7AB90CB8E-0E30B0812599E63C";

            var configBytes = File.ReadAllBytes(path);
            var archive = ConfigArchive.FromBytes(configBytes);

            return PatchedConfigArchive.WithNoPatches(archive);
            //new PatchedConfigArchive(archive);
        }

        private static ISharedGameConfig ImportConfig(PatchedConfigArchive configArchive)
        {
            var factory = GameConfigFactory.Instance;
            return factory.ImportSharedGameConfig(configArchive);
        }
    }
}
