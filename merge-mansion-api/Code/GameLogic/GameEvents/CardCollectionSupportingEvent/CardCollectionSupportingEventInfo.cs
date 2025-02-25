using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using System;
using GameLogic.Player.Requirements;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Code.GameLogic.GameEvents.CardCollectionSupportingEvent
{
    [MetaSerializable]
    [MetaActivableConfigData("CardCollectionSupportingEvent", false, true)]
    public class CardCollectionSupportingEventInfo : IMetaActivableConfigData<CardCollectionSupportingEventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<CardCollectionSupportingEventId>, IHasGameConfigKey<CardCollectionSupportingEventId>, IMetaActivableInfo<CardCollectionSupportingEventId>, IEventSharedInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionSupportingEventId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public PlayerRequirement UnlockRequirement { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public EventGroupId GroupId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public int Priority { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public bool UpgradeUnclaimedPacks { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public bool ShowEndPopup { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        private List<string> EventWhiteList { get; set; }
        public string DisplayShortInfo { get; }
        public CardCollectionSupportingEventId ActivableId { get; }
        public string SharedEventId { get; }

        [IgnoreDataMember]
        public bool UpgradeEverything { get; }

        public CardCollectionSupportingEventInfo()
        {
        }

        public CardCollectionSupportingEventInfo(CardCollectionSupportingEventId configKey, string displayName, string description, MetaActivableParams activableParams, string nameLocId, PlayerRequirement unlockRequirement, EventGroupId groupId, int priority, bool upgradeUnclaimedPacks, bool showEndPopup, List<string> eventWhiteList)
        {
        }
    }
}