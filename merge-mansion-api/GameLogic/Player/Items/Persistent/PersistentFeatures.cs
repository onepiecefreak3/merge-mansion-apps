using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace GameLogic.Player.Items.Persistent
{
    [MetaSerializable]
    public class PersistentFeatures : IPersistentFeatures
    {
        public static PersistentFeatures NoPersistence;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool HasPersistentFeatures { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool HasItemStates { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int DecayCycles { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int ItemStates { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ResetToItem { get; set; }

        public PersistentFeatures()
        {
        }

        public PersistentFeatures(bool hasPersistentFeatures, bool hasItemStates, int decayCycles, int itemStates, MetaRef<ItemDefinition> resetToItem)
        {
        }
    }
}