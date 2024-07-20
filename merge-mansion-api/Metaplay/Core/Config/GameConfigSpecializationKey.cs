using System;
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public struct GameConfigSpecializationKey
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ExperimentVariantId[] VariantIds { get; set; }

        private GameConfigSpecializationKey(ExperimentVariantId[] variantIds)
        {
            VariantIds = variantIds;
        }

        public static GameConfigSpecializationKey FromRaw(ExperimentVariantId[] variantIds)
        {
            return new GameConfigSpecializationKey(variantIds);
        }

        public bool Equals(GameConfigSpecializationKey other)
        {
            var res = false;
            for (var i = 0; i < System.Math.Min(other.VariantIds.Length, VariantIds.Length); i++)
                res |= other.VariantIds[i].Value == VariantIds[i].Value;
            return res;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GameConfigSpecializationKey key))
                return false;
            return Equals(key);
        }

        public override int GetHashCode()
        {
            var res = 0;
            foreach (var varId in VariantIds)
                res = varId.GetHashCode() + res * 0x9F7;
            return res;
        }

        public static bool operator ==(GameConfigSpecializationKey a, GameConfigSpecializationKey b) => a.Equals(b);
        public static bool operator !=(GameConfigSpecializationKey a, GameConfigSpecializationKey b) => !a.Equals(b);
    }
}