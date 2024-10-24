using System;

namespace GameLogic.StatsTracking
{
    public class DailyScoopProgressAnalyticsData
    {
        public int ObjectRequirement;
        public string ObjectiveParameter;
        public int OrderPriority;
        public string ObjectiveCategory;
        public int ObjectiveProgressAmount;
        public int EventPointReceived;
        public string SecondaryReward;
        public string ObjectiveId;
        public int TaskProgress;
        public DailyScoopProgressAnalyticsData(string objectiveId, int objectRequirement, string objectiveParameter, int orderPriority, string objectiveCategory, int objectiveProgressAmount, int eventPointReceived, string secondaryReward, int taskProgress)
        {
        }
    }
}