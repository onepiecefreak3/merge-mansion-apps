using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Player.Items.Chest
{
    [MetaSerializable]
    public class LootRoller
    {
        private static string LootRollerPrefix;
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<LootRoller.LootSequence> RandomLootRollList { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int TotalWeight { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string SpawnId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<MetaRef<ItemDefinition>> ForcedLoot { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<MetaRef<ItemDefinition>> StaticLoot { get; set; }

        private LootRoller()
        {
        }

        public LootRoller(List<ValueTuple<int, int>> randomItemWeights, IEnumerable<int> forcedItems, int itemId)
        {
        }

        public LootRoller(IEnumerable<ValueTuple<int, int>> randomItemWeights, IEnumerable<int> forcedItems, IEnumerable<int> staticItems, string spawnId)
        {
        }

        public LootRoller(IReadOnlyCollection<int> staticItems)
        {
        }

        [MetaSerializable]
        public class LootSequence
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public int Start { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public int End { get; set; }

            [MetaMember(3, (MetaMemberFlags)0)]
            public MetaRef<ItemDefinition> Loot { get; set; }

            public LootSequence()
            {
            }
        }
    }
}