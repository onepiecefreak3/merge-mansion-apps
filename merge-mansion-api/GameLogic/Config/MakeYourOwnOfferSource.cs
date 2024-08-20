using Code.GameLogic.Config;
using Metaplay.Core.Offers;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Config
{
    public class MakeYourOwnOfferSource : IConfigItemSource<MakeYourOwnOfferInfo, MetaOfferId>, IGameConfigSourceItem<MetaOfferId, MakeYourOwnOfferInfo>, IHasGameConfigKey<MetaOfferId>
    {
        public MetaOfferId ConfigKey { get; set; }
        private int SelectableRewardsAmount { get; set; }
        private string RewardPool { get; set; }

        public MakeYourOwnOfferSource()
        {
        }
    }
}