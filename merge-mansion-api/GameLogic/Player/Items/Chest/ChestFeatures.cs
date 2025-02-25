using GameLogic.Player.Items.Production;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Chest
{
    [MetaSerializable]
    public class ChestFeatures : IChestFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsChest { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration OpenDuration { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int HowManyToRoll { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public IItemProducer LootProducer { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string HintLocId { get; set; }

        private static string LootRollerPrefix;
        public static ChestFeatures NoChest;
        private ChestFeatures()
        {
        }

        public ChestFeatures(bool chest, MetaDuration duration, List<ValueTuple<int, int>> itemPairs, List<int> forcedItems, int howMany, int itemId)
        {
        }

        public ChestFeatures(bool chest, MetaDuration duration, List<int> staticItems)
        {
        }

        public ChestFeatures(MetaDuration openDuration, int howManyToRoll, IItemProducer lootProducer, string hintLocId)
        {
        }
    }
}