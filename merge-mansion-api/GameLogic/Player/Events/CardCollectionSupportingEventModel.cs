using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using Code.GameLogic.GameEvents.CardCollectionSupportingEvent;
using System;

namespace GameLogic.Player.Events
{
    [MetaSerializableDerived(21)]
    public class CardCollectionSupportingEventModel : MetaActivableState<CardCollectionSupportingEventId, CardCollectionSupportingEventInfo>
    {
        private static byte InitialBoolFields;
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override CardCollectionSupportingEventId ActivableId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private byte BoolFields { get; set; }
        public bool UpgradeEverything { get; }
        public bool PreviewNoted { get; set; }
        public bool StartNoted { get; set; }
        public bool EndNoted { get; set; }

        private CardCollectionSupportingEventModel()
        {
        }

        public CardCollectionSupportingEventModel(CardCollectionSupportingEventInfo info)
        {
        }
    }
}