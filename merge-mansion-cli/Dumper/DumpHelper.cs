using System;
using System.Collections.Generic;
using Metaplay;
using Metaplay.GameLogic.Area;
using Metaplay.GameLogic.MergeChains;

namespace merge_mansion_cli.Dumper
{
    static class DumpHelper
    {
        private const string MergeChainFileName = "dump/chain_item_odds.json";
        private const string AreaFileName = "dump/areas.json";
        private const string EventFileName = "dump/events.json";
        private const string DialogDirName = "dump/dialogs";

        public static void DumpAll()
        {
            DumpMergeChains();
            DumpAreas();
            DumpEvents();
            DumpDialogs();
        }

        public static void UploadAll()
        {
            // TODO: Implement uploader to wiki
            GetMergeChainData();
            GetAreaData();
            GetEventData();
        }

        public static void DumpMergeChains()
        {
            Console.WriteLine("Dump merge chains... ");

            try
            {
                CreateMergeChainDump().WriteJson(MergeChainFileName, ClientGlobal.SharedGameConfig);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Skipped ({e.Message})");
            }
        }

        public static void DumpAreas()
        {
            Console.WriteLine("Dump areas... ");

            try
            {
                CreateAreaDumper().WriteJson(AreaFileName, ClientGlobal.SharedGameConfig);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Skipped ({e.Message})");
            }
        }

        public static void DumpEvents()
        {
            Console.WriteLine("Dump events... ");

            try
            {
                CreateEventDumper().WriteJson(EventFileName, ClientGlobal.SharedGameConfig);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Skipped ({e.Message})");
            }
        }

        public static void DumpDialogs()
        {
            Console.WriteLine("Dump dialogs... ");

            try
            {
                CreateDialogDumper().ExportImages(DialogDirName, ClientGlobal.SharedGameConfig);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Skipped ({e.Message})");
            }
        }

        public static IList<MergeChainDefinition> GetMergeChainData()
        {
            return CreateMergeChainDump().Dump(ClientGlobal.SharedGameConfig);
        }

        public static IList<AreaInfo> GetAreaData()
        {
            return CreateAreaDumper().Dump(ClientGlobal.SharedGameConfig);
        }

        public static IDictionary<string, object> GetEventData()
        {
            return CreateEventDumper().Dump(ClientGlobal.SharedGameConfig);
        }

        private static MergeChainDumper CreateMergeChainDump()
        {
            return new MergeChainDumper(true);
        }

        private static AreaDumper CreateAreaDumper()
        {
            return new AreaDumper();
        }

        private static EventDumper CreateEventDumper()
        {
            return new EventDumper();
        }

        private static DialogDumper CreateDialogDumper()
        {
            return new DialogDumper();
        }
    }
}
