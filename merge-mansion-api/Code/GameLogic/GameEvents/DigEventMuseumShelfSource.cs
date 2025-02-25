using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    public class DigEventMuseumShelfSource : IConfigItemSource<DigEventMuseumShelfInfo, DigEventMuseumShelfId>, IGameConfigSourceItem<DigEventMuseumShelfId, DigEventMuseumShelfInfo>, IHasGameConfigKey<DigEventMuseumShelfId>
    {
        private static int MaxSlotWidth;
        public DigEventMuseumShelfId ConfigKey { get; set; }
        private List<int> SlotsWidths { get; set; }
        private List<DigEventItemId> Items { get; set; }
        private List<PlayerSegmentId> RewardSegment { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private List<string> ShinyRewardType { get; set; }
        private List<string> ShinyRewardId { get; set; }
        private List<string> ShinyRewardAux0 { get; set; }
        private List<string> ShinyRewardAux1 { get; set; }
        private List<int> ShinyRewardAmount { get; set; }
        private List<PlayerSegmentId> ShinyRewardSegment { get; set; }

        public DigEventMuseumShelfSource()
        {
        }
    }
}