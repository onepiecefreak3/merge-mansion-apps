namespace Metaplay.Core.Config
{
    public class GameConfigImporter
    {
        private PatchedConfigArchive _archive; // 0x10
        private GameConfigBase _config; // 0x18
        //private CsvParseOptions _parseOptions; // 0x20

        public GameConfigImporter(PatchedConfigArchive archive, IGameConfigDataResolver baseResolver, GameConfigBase config/*, CsvParseOptions parseOptions*/)
        {
            _archive = archive;
            _config = config;
        }

        public bool Contains(string fileName)
        {
            return _archive.BaselineArchive.ContainsEntryWithName(fileName);
        }

        public GameConfigLibrary<TKey, TValue> ImportBinaryLibrary<TKey, TValue>(string fileName)
            where TValue : IGameConfigData<TKey>
        {
            return _archive.LoadBinaryLibrary<TKey, TValue>(_config, fileName);
        }

        public T ImportBinaryKeyValueStructure<T>(string fileName, bool allowPartial = false)
        {
            return _archive.LoadBinaryKeyValueStructure<T>(fileName);
        }
    }
}
