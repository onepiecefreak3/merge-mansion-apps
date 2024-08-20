using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    [MetaSerializable]
    public class DailyScoopWeekData : IGameConfigData<DailyScoopWeekId>, IGameConfigData, IHasGameConfigKey<DailyScoopWeekId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyScoopWeekId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<DailyScoopDayId> EventDayKeys { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<DailyScoopMilestoneId> Milestones { get; set; }

        public DailyScoopWeekData()
        {
        }

        public DailyScoopWeekData(DailyScoopWeekId configKey, List<DailyScoopDayId> eventDayKeys, List<DailyScoopMilestoneId> milestones)
        {
        }
    }
}