using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableSet("BoultonLeagueEvent", false)]
    [MetaSerializableDerived(17)]
    public class PlayerBoultonLeagueEventsModel : MetaActivableSet<BoultonLeagueEventId, BoultonLeagueEventInfo, BoultonLeagueEventModel>
    {
        public PlayerBoultonLeagueEventsModel()
        {
        }
    }
}