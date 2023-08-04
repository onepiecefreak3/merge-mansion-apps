using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System.Runtime.Serialization;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(4)]
    public class EventOfferModel : MetaActivableState<EventOfferId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventOfferInfo Info { get; set; }

        [IgnoreDataMember]
        public override EventOfferId ActivableId { get; }

        [IgnoreDataMember]
        public override MetaActivableParams ActivableParams { get; }

        private EventOfferModel()
        {
        }

        public EventOfferModel(EventOfferInfo info)
        {
        }
    }
}