using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(5)]
    [MetaActivableSet("GarageCleanupEvent", false)]
    public class PlayerGarageCleanupEventsModel : MetaActivableSet<GarageCleanupEventId, GarageCleanupEventInfo, GarageCleanupEventModel>
    {
        public PlayerGarageCleanupEventsModel()
        {
        }
    }
}