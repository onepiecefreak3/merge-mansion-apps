using System;
using System.Collections.Generic;
using System.Linq;
using static Metaplay.Core.Network.MessageTransport;

namespace Metaplay.Core.Config
{
    public class PatchedConfigArchive
    {
        private ConfigArchive _archive; // 0x10
        private GameConfigPatchEnvelope[] _patches; // 0x18

        public ConfigArchive BaselineArchive => _archive;

        public PatchedConfigArchive(ConfigArchive archive, IEnumerable<GameConfigPatchEnvelope> patches)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
            _patches = patches.ToArray();
        }

        public static PatchedConfigArchive WithNoPatches(ConfigArchive archive)
        {
            return new PatchedConfigArchive(archive, Enumerable.Empty<GameConfigPatchEnvelope>());
        }

        internal GameConfigLibrary<TKey, TInfo> LoadBinaryLibrary<TKey, TInfo>(IGameConfigDataRegistry registry, string fileName)
            where TInfo : IGameConfigData<TKey>
        {
            var entryName = MpcFileNameToEntryName(fileName);

            var items = GameConfigUtil.ImportBinaryLibraryItems<TKey, TInfo>(_archive, fileName);
            PatchEntryContentInPlace(items, entryName, typeof(GameConfigLibraryPatch<TKey, TInfo>));

            var lib = GameConfigLibrary<TKey, TInfo>.FromItems(items, registry);

            var aliasFileName = entryName + ".AliasTable.mpc";
            if (_archive.ContainsEntryWithName(aliasFileName))
                GameConfigUtil.ImportBinaryLibraryAliases(lib, _archive, aliasFileName);

            return lib;
        }

        internal TStructure LoadBinaryKeyValueStructure<TStructure>(string fileName)
        {
            var entryName = MpcFileNameToEntryName(fileName);

            var item = GameConfigUtil.ImportBinaryKeyValueStructure<TStructure>(_archive, fileName);
            PatchEntryContentInPlace(item, entryName, typeof(GameConfigStructurePatch<TStructure>));

            return item;
        }

        internal void PatchEntryContentInPlace(object entryContent, string entryName, Type entryPatchType)
        {
            if (_patches.Length <= 0)
                return;

            foreach (var patch in _patches)
                patch.PatchEntryContentInPlace(entryContent, entryName, entryPatchType);
        }

        private static string MpcFileNameToEntryName(string fileName)
        {
            if (!fileName.EndsWith(".mpc"))
                throw new ArgumentException("Expected binary library file name to end in .mpc: " + fileName);

            return fileName.Substring(0, fileName.Length - 4);
        }
    }
}
