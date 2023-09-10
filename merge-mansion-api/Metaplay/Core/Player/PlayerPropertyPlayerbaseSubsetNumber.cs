using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [MetaSerializableDerived(100)]
    public class PlayerPropertyPlayerbaseSubsetNumber : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int NumSubsets;
        [MetaMember(2, (MetaMemberFlags)0)]
        public uint Modifier;

        public override string DisplayName => $"Playerbase subset number out of total {NumSubsets} (with hash modifier {Modifier})";

        private PlayerPropertyPlayerbaseSubsetNumber()
        {
        }

        public PlayerPropertyPlayerbaseSubsetNumber(int numSubsets, uint modifier)
        {
        }
    }
}