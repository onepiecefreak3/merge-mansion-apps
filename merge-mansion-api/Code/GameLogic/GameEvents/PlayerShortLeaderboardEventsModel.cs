using Metaplay.Core.Activables;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableSet("ShortLeaderboardEvent", false)]
    [MetaSerializableDerived(19)]
    public class PlayerShortLeaderboardEventsModel : MetaActivableSet<ShortLeaderboardEventId, ShortLeaderboardEventInfo, ShortLeaderboardEventModel>
    {
        public PlayerShortLeaderboardEventsModel()
        {
        }
    }
}