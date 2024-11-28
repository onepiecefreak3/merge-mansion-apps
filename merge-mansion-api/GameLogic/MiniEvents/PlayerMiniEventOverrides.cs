using Metaplay.Core.Model;
using GameLogic.Config.Shop.PriceCurves;
using Metaplay.Core;
using GameLogic.Config;
using System;

namespace GameLogic.MiniEvents
{
    [MetaSerializable]
    public class PlayerMiniEventOverrides
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MiniEventOverrideDictionary<ShopItemId, IPriceCurve> PriceCurveOverrides { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MiniEventOverrides<MetaDuration> EnergyUnitRestoreDurationOverrides { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MiniEventOverrides<SpeedUpBehavior> SpeedUpBehaviorOverrides { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MiniEventOverrides<int> ProducerTimeSkipPriceOverrides { get; set; }

        public PlayerMiniEventOverrides()
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MiniEventOverrides<int> ProducerCapacityOverrides { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MiniEventOverrides<int> ProducerTimerOverrides { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MiniEventOverrides<int> BubblePriceOverrides { get; set; }
    }
}