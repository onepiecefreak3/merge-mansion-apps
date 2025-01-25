using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using Merge;
using Metaplay.Core;
using System.Collections.Generic;
using GameLogic.Config.Costs;
using GameLogic.Player.Rewards;
using System;
using Metaplay.Core.Offers;
using GameLogic.Story;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ShortLeaderboardEventStageInfo : IGameConfigData<ShortLeaderboardEventStageId>, IGameConfigData, IHasGameConfigKey<ShortLeaderboardEventStageId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ShortLeaderboardEventStageId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaDuration StartTime { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaDuration Duration { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<GameCurrencyCost> ReplayCosts { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<PlayerReward> CompletionRewards { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<int> RankingPositionStars { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public OfferPlacementId BoardShopPlacementId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public int AuxEnergyAttachmentChance { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public int StarsToComplete { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public List<MetaRef<EventLevelInfo>> LevelRefs { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public StoryDefinitionId EnterBoardDialogue { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public StoryDefinitionId CompletionDialogue { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public MetaDuration ReplayCostCooldown { get; set; }

        public ShortLeaderboardEventStageInfo()
        {
        }

        public ShortLeaderboardEventStageInfo(ShortLeaderboardEventStageId configKey, MergeBoardId boardId, MetaDuration startTime, MetaDuration duration, List<GameCurrencyCost> replayCosts, List<PlayerReward> completionRewards, List<int> rankingPositionStars, OfferPlacementId boardShopPlacementId, int auxEnergyAttachmentChance, int starsToComplete, List<MetaRef<EventLevelInfo>> levelRefs, StoryDefinitionId enterBoardDialogue, StoryDefinitionId completionDialogue, MetaDuration replayCostCooldown)
        {
        }
    }
}