using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineCurrencyItemInfo : IGameConfigData<MysteryMachineCurrencyItemId>, IGameConfigData, IHasGameConfigKey<MysteryMachineCurrencyItemId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineCurrencyItemId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public Currencies Currency { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int DisplayAmount { get; set; }

        public MysteryMachineCurrencyItemInfo()
        {
        }

        public MysteryMachineCurrencyItemInfo(MysteryMachineCurrencyItemId configKey, Currencies currency, int amount, int displayAmount)
        {
        }
    }
}