using Metaplay;

namespace merge_mansion_cli.Dumper
{
    static class DumpHelper
    {
        private const string MergeChainFileName = "chain_item_odds.json";
        private const string AreaFileName = "areas.json";
        private const string EventFileName = "events.json";
        private const string DialogDirName = "dialogs";

        public static void DumpAll()
        {
            DumpMergeChains();
            DumpAreas();
            DumpEvents();
            DumpDialogs();
        }

        public static void DumpMergeChains()
        {
            new ChainDumper(true).WriteJson(MergeChainFileName, ClientGlobal.SharedGameConfig);
        }

        public static void DumpAreas()
        {
            new AreaDumper().WriteJson(AreaFileName, ClientGlobal.SharedGameConfig);
        }

        public static void DumpEvents()
        {
            new EventDumper().WriteJson(EventFileName, ClientGlobal.SharedGameConfig);
        }

        public static void DumpDialogs()
        {
            new DialogDumper().ExportImages(DialogDirName, ClientGlobal.SharedGameConfig);
        }
    }
}
