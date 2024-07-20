using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableSet("LeaderboardEvent", false)]
    [MetaSerializableDerived(9)]
    public class PlayerLeaderboardEventsModel : MetaActivableSet<LeaderboardEventId, LeaderboardEventInfo, LeaderboardEventModel>
    {
        public PlayerLeaderboardEventsModel()
        {
        }
    }
}