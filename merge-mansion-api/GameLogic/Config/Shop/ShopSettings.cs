using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Code.GameLogic.FlashSales;
using System;
using System.Runtime.Serialization;
using Code.GameLogic.Config;

namespace GameLogic.Config.Shop
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 4 })]
    public class ShopSettings : GameConfigKeyValue<ShopSettings>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<FlashSaleSlotId> ActiveFlashSaleSlots { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int CompleteReRollAttempts { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private Currencies FlashResetCurrency { get; set; }

        public ShopSettings()
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<int> FlashResetCosts { get; set; }
    }
}