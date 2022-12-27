using System;
using System.Collections.Generic;
using System.Linq;

namespace Metaplay.Metaplay.Core.Config
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

        internal GameConfigLibrary<TKey, TInfo> LoadBinaryLibrary<TKey, TInfo>(IGameConfigDataResolver resolver, IGameConfigDataRegistry registry, string fileName)
            where TInfo : IGameConfigData<TKey>
        {
            var entryName = MpcFileNameToEntryName(fileName);

            var items = GameConfigUtil.ImportBinaryLibraryItems<TKey, TInfo>(resolver, _archive, fileName);
            PatchEntryContentInPlace(items, resolver, entryName, typeof(TInfo));

            var lib = GameConfigLibrary<TKey, TInfo>.FromItems(items, registry);

            var aliasFileName = entryName + ".AliasTable.mpc";
            if (_archive.ContainsEntryWithName(aliasFileName))
                GameConfigUtil.ImportBinaryLibraryAliases(lib, _archive, aliasFileName);

            return lib;
        }

        //internal TStructure LoadBinaryKeyValueStructure<TStructure>(IGameConfigDataResolver resolver, string fileName)
        //{

        //}

        internal void PatchEntryContentInPlace(object entryContent, IGameConfigDataResolver resolver, string entryName, Type entryPatchType)
        {
            // TODO: Implement
        }

        private static string MpcFileNameToEntryName(string fileName)
        {
            if (!fileName.EndsWith(".mpc"))
                throw new ArgumentException("Expected binary library file name to end in .mpc: " + fileName);

            return fileName.Substring(0, fileName.Length - 4);
        }
    }
}
