using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    public class ResolvedPurchaseGameContent : ResolvedPurchaseContentBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<InAppProductRewardCurrency> GainedCurrencies { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<InAppProductRewardItem> GainedItems { get; set; }

        public ResolvedPurchaseGameContent()
        {
        }

        public ResolvedPurchaseGameContent(IEnumerable<ICurrencyReward> currencyRewards, IEnumerable<RewardItem> itemRewards)
        {
        }
    }
}