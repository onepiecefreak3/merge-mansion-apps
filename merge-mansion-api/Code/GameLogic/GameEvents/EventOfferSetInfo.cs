using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Player.Rewards;
using System.Runtime.Serialization;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventOfferSetInfo : IGameConfigData<EventOfferSetId>, IGameConfigData, IValidatable
    {
        [MetaMember(5, (MetaMemberFlags)0)]
        public string NameLocalizationId { get; set; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public EventOfferSetId EventOfferSetId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<MetaRef<EventOfferInfo>> EventOfferRefs { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<MetaRef<EventOfferSetInfo>> PrecursorEventOfferSetRefs { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        public EventOfferSetId ConfigKey => EventOfferSetId;

        [IgnoreDataMember]
        public IEnumerable<EventOfferInfo> EventOffers { get; }

        [IgnoreDataMember]
        public IEnumerable<EventOfferSetInfo> PrecursorEventOfferSets { get; }

        public EventOfferSetInfo()
        {
        }

        public EventOfferSetInfo(string nameLocalizationId, EventOfferSetId eventOfferSetId, List<MetaRef<EventOfferInfo>> eventOfferRefs, List<MetaRef<EventOfferSetInfo>> precursorEventOfferSetRefs, List<PlayerReward> rewards)
        {
        }
    }
}