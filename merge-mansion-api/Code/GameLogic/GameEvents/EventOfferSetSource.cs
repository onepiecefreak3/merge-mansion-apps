using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class EventOfferSetSource : IConfigItemSource<EventOfferSetInfo, EventOfferSetId>, IGameConfigSourceItem<EventOfferSetId, EventOfferSetInfo>, IHasGameConfigKey<EventOfferSetId>
    {
        private string NameLocalizationId { get; set; }
        private EventOfferSetId EventOfferSetId { get; set; }
        private List<MetaRef<EventOfferInfo>> EventOffers { get; set; }
        private List<MetaRef<EventOfferSetInfo>> PrecursorEventOfferSets { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        public EventOfferSetId ConfigKey { get; }

        public EventOfferSetSource()
        {
        }
    }
}