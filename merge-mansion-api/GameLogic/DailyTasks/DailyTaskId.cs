using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.DailyTasks
{
    [MetaSerializable]
    public class DailyTaskId : StringId<DailyTaskId>
    {
        public DailyTaskId()
        {
        }
    }
}