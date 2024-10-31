using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(9)]
    [MetaActivableSet("LeaderboardEvent", false)]
    public class PlayerLeaderboardEventsModel : MetaActivableSet<LeaderboardEventId, LeaderboardEventInfo, LeaderboardEventModel>
    {
        public PlayerLeaderboardEventsModel()
        {
        }
    }
}