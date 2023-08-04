using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Player.ScheduledActions
{
    [MetaSerializable]
    public class ScheduledActionId : StringId<ScheduledActionId>
    {
        public static ScheduledActionId GarageFlashSaleRefresh;
        public ScheduledActionId()
        {
        }
    }
}