using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents.CardCollectionSupportingEvent;

namespace GameLogic.Player.Events
{
    [MetaActivableSet("CardCollectionSupportingEvent", false)]
    [MetaSerializableDerived(21)]
    public class PlayerCardCollectionSupportingEventsModel : MetaActivableSet<CardCollectionSupportingEventId, CardCollectionSupportingEventInfo, CardCollectionSupportingEventModel>
    {
        public PlayerCardCollectionSupportingEventsModel()
        {
        }
    }
}