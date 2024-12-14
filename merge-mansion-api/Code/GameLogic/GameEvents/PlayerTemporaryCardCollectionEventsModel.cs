using Metaplay.Core.Activables;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(18)]
    [MetaActivableSet("TemporaryCardCollectionEvent", false)]
    public class PlayerTemporaryCardCollectionEventsModel : MetaActivableSet<TemporaryCardCollectionEventId, TemporaryCardCollectionEventInfo, TemporaryCardCollectionEventModel>
    {
        public PlayerTemporaryCardCollectionEventsModel()
        {
        }
    }
}