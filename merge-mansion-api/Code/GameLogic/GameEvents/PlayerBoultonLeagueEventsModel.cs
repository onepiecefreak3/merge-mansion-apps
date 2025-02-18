using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(17)]
    [MetaActivableSet("BoultonLeagueEvent", false)]
    public class PlayerBoultonLeagueEventsModel : MetaActivableSet<BoultonLeagueEventId, BoultonLeagueEventInfo, BoultonLeagueEventModel>
    {
        public PlayerBoultonLeagueEventsModel()
        {
        }
    }
}