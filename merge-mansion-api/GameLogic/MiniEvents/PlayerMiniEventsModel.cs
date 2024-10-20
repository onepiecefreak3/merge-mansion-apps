using Metaplay.Core.Activables;
using Metaplay.Core.Model;

namespace GameLogic.MiniEvents
{
    [MetaSerializableDerived(15)]
    [MetaActivableSet("MiniEvent", false)]
    public class PlayerMiniEventsModel : MetaActivableSet<MiniEventId, MiniEventInfo, MiniEventModel>
    {
        public PlayerMiniEventsModel()
        {
        }
    }
}