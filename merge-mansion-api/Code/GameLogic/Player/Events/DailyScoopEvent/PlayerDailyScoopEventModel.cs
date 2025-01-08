using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents.DailyScoop;

namespace Code.GameLogic.Player.Events.DailyScoopEvent
{
    [MetaSerializable]
    [MetaActivableSet("DailyScoopEvent", false)]
    public class PlayerDailyScoopEventModel : MetaActivableSet<DailyScoopEventId, DailyScoopEventInfo, DailyScoopEventModel>
    {
        public PlayerDailyScoopEventModel()
        {
        }
    }
}