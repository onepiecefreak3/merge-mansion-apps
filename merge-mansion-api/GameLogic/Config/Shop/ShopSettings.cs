using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Code.GameLogic.FlashSales;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Config.Shop
{
    [MetaSerializable]
    public class ShopSettings : GameConfigKeyValue<ShopSettings>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<FlashSaleSlotId> ActiveFlashSaleSlots { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int CompleteReRollAttempts { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private Currencies FlashResetCurrency { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private int FlashResetCost { get; set; }

        [IgnoreDataMember]
        public (Currencies Currency, int Cost) FlashResetPrice => (FlashResetCurrency, FlashResetCost);

        public ShopSettings()
        {
        }
    }
}