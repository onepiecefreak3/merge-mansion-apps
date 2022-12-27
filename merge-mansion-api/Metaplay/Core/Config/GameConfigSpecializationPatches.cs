using System;
using System.Collections.Generic;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Player;
using Metaplay.Metaplay.Core.Serialization;

namespace Metaplay.Metaplay.Core.Config
{
    public class GameConfigSpecializationPatches
    {
        [MetaMember(1, 0)]
        public ContentHash Version { get; set; }  // 0x10
        [MetaMember(2, 0)]
        public Dictionary<PlayerExperimentId, Dictionary<ExperimentVariantId, byte[]>> Patches { get; set; } // 0x20

        private GameConfigSpecializationPatches()
        { }

        private GameConfigSpecializationPatches(ContentHash version, Dictionary<PlayerExperimentId, Dictionary<ExperimentVariantId, byte[]>> patches)
        {
            Version = version;
            Patches = patches;
        }

        // RVA: 0xF19408 Offset: 0xF19408 VA: 0xF19408
        public GameConfigSpecializationKey CreateKeyFromAssignment(Dictionary<PlayerExperimentId, ExperimentVariantId> assignment)
        {
            var varIds = new ExperimentVariantId[Patches.Count];
            var index = 0;
            foreach (var patch in Patches)
            {
                ExperimentVariantId expVarId = null;
                if (assignment.TryGetValue(patch.Key, out expVarId))
                {
                    if (expVarId != null)
                    {
                        if (!patch.Value.ContainsKey(expVarId))
                            throw new InvalidOperationException($"cannot create specialization key, unknown variant {expVarId.Value} in experiment {patch.Key.Value}");
                    }
                }

                varIds[index++] = expVarId;
            }

            return new GameConfigSpecializationKey { VariantIds = varIds };
        }

        public List<GameConfigPatchEnvelope> GetPatchesForSpecialization(GameConfigSpecializationKey specializationKey)
        {
            var envelopes = new List<GameConfigPatchEnvelope>();

            var i = 0;
            foreach (var patch in Patches.Values)
            {
                var variantId = specializationKey.VariantIds[i++];

                if (variantId != null)
                    envelopes.Add(GameConfigPatchEnvelope.Deserialize(patch[variantId]));
            }

            return envelopes;
        }

        // RVA: 0xF19A60 Offset: 0xF19A60 VA: 0xF19A60
        //public byte[] ToBytes() { }

        public static GameConfigSpecializationPatches FromBytes(byte[] bytes)
        {
            return MetaSerialization.DeserializeTagged<GameConfigSpecializationPatches>(bytes, MetaSerializationFlags.IncludeAll, null, null, null);
        }

        // RVA: 0xF19B20 Offset: 0xF19B20 VA: 0xF19B20
        //public static GameConfigSpecializationPatches FromContents(ContentHash version, Dictionary<PlayerExperimentId, Dictionary<ExperimentVariantId, byte[]>> patches) { }
    }
}
