using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using GameLogic.Player.Items.Production;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializable]
    public class TagRewardsInfo : IGameConfigData<string>, IGameConfigData, IHasGameConfigKey<string>
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public int TotalPoints;
        [MetaMember(3, (MetaMemberFlags)0)]
        public string RewardTagName;
        [MetaMember(4, (MetaMemberFlags)0)]
        public IItemProducer ItemProducer;
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ConfigKey { get; set; }

        public TagRewardsInfo()
        {
        }

        public TagRewardsInfo(string configKey, int totalPoints, string rewardTagName, IItemProducer itemProducer)
        {
        }
    }
}