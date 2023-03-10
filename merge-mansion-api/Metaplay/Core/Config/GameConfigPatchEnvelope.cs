using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Serialization;

namespace Metaplay.Metaplay.Core.Config
{
    public class GameConfigPatchEnvelope
    {
        private Dictionary<string, byte[]> _serializedEntryPatches; // 0x10

        public bool IsEmpty => !_serializedEntryPatches.Any();

        internal GameConfigPatchEnvelope(Dictionary<string, byte[]> serializedEntryPatches)
        {
            _serializedEntryPatches = serializedEntryPatches;
        }

        public static GameConfigPatchEnvelope Deserialize(byte[] serializedEnvelope)
        {
            var deserialized = MetaSerialization.DeserializeTagged<Dictionary<string, byte[]>>(serializedEnvelope, MetaSerializationFlags.IncludeAll, null, null, null);
            return new GameConfigPatchEnvelope(deserialized);
        }
    }
}
