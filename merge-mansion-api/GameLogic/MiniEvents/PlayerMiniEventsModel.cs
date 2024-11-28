using Metaplay.Core.Activables;
using Metaplay.Core.Model;

namespace GameLogic.MiniEvents
{
    [MetaActivableSet("MiniEvent", false)]
    [MetaSerializableDerived(15)]
    public class PlayerMiniEventsModel : MetaActivableSet<MiniEventId, MiniEventInfo, MiniEventModel>
    {
        public PlayerMiniEventsModel()
        {
        }
    }
}