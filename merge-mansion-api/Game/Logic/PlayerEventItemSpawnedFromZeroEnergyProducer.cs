using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(22, "Item spawned with no energy", 1, null, true, false, false)]
    public class PlayerEventItemSpawnedFromZeroEnergyProducer : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ProducedItemType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ProducerName { get; set; }
        public override string EventDescription { get; }

        private PlayerEventItemSpawnedFromZeroEnergyProducer()
        {
        }

        public PlayerEventItemSpawnedFromZeroEnergyProducer(string producedItemType, string producerName)
        {
        }
    }
}