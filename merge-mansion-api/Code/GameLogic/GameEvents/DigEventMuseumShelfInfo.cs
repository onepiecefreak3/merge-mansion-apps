using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventMuseumShelfInfo : IGameConfigData<DigEventMuseumShelfId>, IGameConfigData, IHasGameConfigKey<DigEventMuseumShelfId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DigEventMuseumShelfId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int SlotsAmount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<int> SlotsWidths { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private List<PlayerReward> Rewards { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<PlayerSegmentId> RewardSegments { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        private List<PlayerReward> ShinyRewards { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<PlayerSegmentId> ShinyRewardSegments { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<DigEventItemId> Items { get; set; }
        public bool AnyItemInSlots { get; }
        public bool StartsShiny { get; }
        public bool ShinyUpgrade { get; }

        public DigEventMuseumShelfInfo()
        {
        }

        public DigEventMuseumShelfInfo(DigEventMuseumShelfId configKey, List<int> slotsWidths, List<DigEventItemId> items, List<PlayerReward> rewards, List<PlayerSegmentId> rewardSegments, List<PlayerReward> shinyRewards, List<PlayerSegmentId> shinyRewardSegments)
        {
        }
    }
}