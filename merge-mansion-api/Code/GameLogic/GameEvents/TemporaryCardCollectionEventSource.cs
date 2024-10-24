using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using GameLogic.CardCollection;

namespace Code.GameLogic.GameEvents
{
    public class TemporaryCardCollectionEventSource : IConfigItemSource<TemporaryCardCollectionEventInfo, TemporaryCardCollectionEventId>, IGameConfigSourceItem<TemporaryCardCollectionEventId, TemporaryCardCollectionEventInfo>, IHasGameConfigKey<TemporaryCardCollectionEventId>
    {
        public TemporaryCardCollectionEventId ConfigKey { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private string NameLocId { get; set; }
        private List<CardCollectionCardSetId> CardSetIds { get; set; }
        private CardCollectionBalanceId BalanceId { get; set; }
        private List<CardCollectionEvidenceBoxId> EvidenceBoxIds { get; set; }
        private OddsPopupStyle OddsPopupStyle { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private List<string> PrestigeRewardType { get; set; }
        private List<string> PrestigeRewardId { get; set; }
        private List<string> PrestigeRewardAux0 { get; set; }
        private List<string> PrestigeRewardAux1 { get; set; }
        private List<int> PrestigeRewardAmount { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }

        public TemporaryCardCollectionEventSource()
        {
        }
    }
}