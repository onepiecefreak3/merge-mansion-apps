using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace GameLogic.Player.ScheduledActions
{
    [MetaSerializableDerived(1)]
    [MetaActivableSet("ScheduledAction", false)]
    public class PlayerScheduledActions : MetaActivableSet<ScheduledActionId, ScheduledActionInfo, ScheduledAction>
    {
        public PlayerScheduledActions()
        {
        }
    }
}