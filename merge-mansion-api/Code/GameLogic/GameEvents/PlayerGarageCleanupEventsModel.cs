using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableSet("GarageCleanupEvent", false)]
    [MetaSerializableDerived(5)]
    public class PlayerGarageCleanupEventsModel : MetaActivableSet<GarageCleanupEventId, GarageCleanupEventInfo, GarageCleanupEventModel>
    {
        public PlayerGarageCleanupEventsModel()
        {
        }
    }
}