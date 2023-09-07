using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.Core.Serialization;

namespace Metaplay.Core.Config
{
    public class GameConfigPatchEnvelope
    {
        private Dictionary<string, byte[]> _serializedEntryPatches; // 0x10

        public bool IsEmpty => !_serializedEntryPatches.Any();

        internal GameConfigPatchEnvelope(Dictionary<string, byte[]> serializedEntryPatches)
        {
            _serializedEntryPatches = serializedEntryPatches;
        }

        public void PatchEntryContentInPlace(object entryContent, string entryName, Type entryPatchType)
        {
            if (!TryDeserializeEntryPatch(entryName, entryPatchType, out var deserialized))
                return;

            deserialized.PatchContentDangerouslyInPlace(entryContent);
        }

        public bool TryDeserializeEntryPatch(string entryName, Type entryPatchType, out GameConfigEntryPatch entryPatch)
        {
            entryPatch = null;

            if (!_serializedEntryPatches.TryGetValue(entryName, out var entry))
                return false;

            var deserialized = MetaSerialization.DeserializeTagged(entry, entryPatchType, MetaSerializationFlags.IncludeAll, null, null, null);
            if (deserialized is GameConfigEntryPatch patch)
                entryPatch = patch;

            return true;
        }

        public static GameConfigPatchEnvelope Deserialize(byte[] serializedEnvelope)
        {
            var deserialized = MetaSerialization.DeserializeTagged<Dictionary<string, byte[]>>(serializedEnvelope, MetaSerializationFlags.IncludeAll, null, null, null);
            return new GameConfigPatchEnvelope(deserialized);
        }
    }
}
