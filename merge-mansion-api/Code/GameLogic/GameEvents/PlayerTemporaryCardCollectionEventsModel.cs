using Metaplay.Core.Activables;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableSet("TemporaryCardCollectionEvent", false)]
    [MetaSerializableDerived(18)]
    public class PlayerTemporaryCardCollectionEventsModel : MetaActivableSet<TemporaryCardCollectionEventId, TemporaryCardCollectionEventInfo, TemporaryCardCollectionEventModel>
    {
        public PlayerTemporaryCardCollectionEventsModel()
        {
        }
    }
}