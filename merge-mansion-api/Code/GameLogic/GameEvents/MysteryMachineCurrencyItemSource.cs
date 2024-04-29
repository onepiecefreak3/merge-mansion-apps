using Code.GameLogic.Config;
using Metaplay.Core.Config;
using GameLogic;
using System;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineCurrencyItemSource : IConfigItemSource<MysteryMachineCurrencyItemInfo, MysteryMachineCurrencyItemId>, IGameConfigSourceItem<MysteryMachineCurrencyItemId, MysteryMachineCurrencyItemInfo>, IHasGameConfigKey<MysteryMachineCurrencyItemId>
    {
        public MysteryMachineCurrencyItemId ConfigKey { get; set; }
        private Currencies Currency { get; set; }
        private int Amount { get; set; }
        private int DisplayAmount { get; set; }

        public MysteryMachineCurrencyItemSource()
        {
        }
    }
}