using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    public class DailyScoopWeekDataSource : IConfigItemSource<DailyScoopWeekData, DailyScoopWeekId>, IGameConfigSourceItem<DailyScoopWeekId, DailyScoopWeekData>, IHasGameConfigKey<DailyScoopWeekId>
    {
        public DailyScoopWeekId ConfigKey { get; set; }
        public List<DailyScoopDayId> DayKeys { get; set; }
        public List<DailyScoopMilestoneId> MilestoneKeys { get; set; }

        public DailyScoopWeekDataSource()
        {
        }
    }
}