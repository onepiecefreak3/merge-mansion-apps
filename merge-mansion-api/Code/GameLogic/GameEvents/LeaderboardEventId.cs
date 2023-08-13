using Metaplay.Core;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class LeaderboardEventId : StringId<LeaderboardEventId>
    {
        public LeaderboardEventId()
        {
        }
    }
}