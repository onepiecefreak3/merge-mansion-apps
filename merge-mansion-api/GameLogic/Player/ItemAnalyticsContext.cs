using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace GameLogic.Player
{
    [MetaSerializableDerived(2)]
    public class ItemAnalyticsContext : AnalyticsContext
    {
        [MetaMember(10, (MetaMemberFlags)0)]
        public List<string> SpawnedItems { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public bool FromInventory { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public bool FromPocket { get; set; }

        public ItemAnalyticsContext()
        {
        }

        public ItemAnalyticsContext(string context, string target, List<string> spawnedItems, bool fromInventory, bool fromPocket)
        {
        }
    }
}