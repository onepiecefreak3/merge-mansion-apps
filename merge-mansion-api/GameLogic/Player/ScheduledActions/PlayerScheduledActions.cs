using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace GameLogic.Player.ScheduledActions
{
    [MetaActivableSet("ScheduledAction", false)]
    [MetaSerializableDerived(1)]
    public class PlayerScheduledActions : MetaActivableSet<ScheduledActionId, ScheduledActionInfo, ScheduledAction>
    {
        public PlayerScheduledActions()
        {
        }
    }
}