using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System;
using GameLogic.Story;
using System.Collections.Generic;
using GameLogic.Player;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(6)]
    public class ProgressionEventModel : MetaActivableState<ProgressionEventId, ProgressionEventInfo>
    {
        public static int InitialLevelNumber;
        private static int InitialLevelProgress;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int LevelNumber;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int LevelProgress;
        [MetaMember(6, (MetaMemberFlags)0)]
        public bool StartNoted;
        [MetaMember(8, (MetaMemberFlags)0)]
        public bool EndNoted;
        [MetaMember(12, (MetaMemberFlags)0)]
        public bool EndDialogueTriggered;
        [MetaMember(7, (MetaMemberFlags)0)]
        public bool PremiumIAPPurchased;
        [MetaMember(9, (MetaMemberFlags)0)]
        public bool RewardMailTriggered;
        [MetaMember(11, (MetaMemberFlags)0)]
        public HashSet<StoryDefinitionId> TriggeredLevelRewardClaimedStories;
        [MetaMember(13, (MetaMemberFlags)0)]
        public BoardInventory ExtraInventory;
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override ProgressionEventId ActivableId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<int> ClaimedFreeLevelNumbers { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<int> ClaimedPremiumLevelNumbers { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public Dictionary<ProgressionEventPerkId, MetaTime> LatestFreeShopItemPerkUsageTimesById { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public Dictionary<ProgressionEventPerkId, MetaTime> LatestFreeDailyShopItemPerkUsageTimesById { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public Dictionary<ProgressionEventPerkId, MetaTime> LatestFreeDailyCurrencyPerkUsageTimeById { get; set; }

        private ProgressionEventModel()
        {
        }

        public ProgressionEventModel(ProgressionEventInfo info)
        {
        }
    }
}