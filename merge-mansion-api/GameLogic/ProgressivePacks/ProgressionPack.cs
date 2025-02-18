using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using System;
using GameLogic.StatsTracking;

namespace GameLogic.ProgressivePacks
{
    [MetaSerializable]
    public class ProgressionPack : IGameConfigData<ProgressionPackId>, IGameConfigData, IHasGameConfigKey<ProgressionPackId>
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> FreeOffers;
        [MetaMember(4, (MetaMemberFlags)0)]
        public List<PlayerReward> PremiumOffers;
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionPackId OfferId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<int> LevelRequirements { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public StatsObjectiveType ObjectiveType { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<string> ObjectiveParameter { get; set; }
        public ProgressionPackId ConfigKey => OfferId;

        public ProgressionPack()
        {
        }

        public ProgressionPack(ProgressionPackId id, List<PlayerReward> freeOffer, List<PlayerReward> premiumOffer, List<int> levels, StatsObjectiveType objectiveType, List<string> objectiveParameter)
        {
        }
    }
}