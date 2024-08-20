using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core.Offers;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class MakeYourOwnOfferInfo : IGameConfigData<MetaOfferId>, IGameConfigData, IHasGameConfigKey<MetaOfferId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int SelectableRewardsAmount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> RewardPool { get; set; }

        public MakeYourOwnOfferInfo()
        {
        }

        public MakeYourOwnOfferInfo(MetaOfferId configKey, int selectableRewardsAmount, List<PlayerReward> rewardPool)
        {
        }
    }
}