using System.Collections.Generic;

namespace merge_mansion_dumper.Models.Area
{
    class AreaModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IDictionary<RequirementType, IList<RequireModel>> TeaseAt { get; set; }
        public IDictionary<RequirementType, IList<RequireModel>> UnlockAt { get; set; }
        public string TaskDependencies { get; set; }
        public IList<TaskModel> Tasks { get; set; }
        public IList<RewardModel> Rewards { get; set; }
    }
}
