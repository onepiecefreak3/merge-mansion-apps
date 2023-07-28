using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace merge_mansion_dumper.Models.Area
{
    public class TaskModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public IDictionary<RequirementType, IList<RequireModel>> Requirements { get; set; }
        public IList<RewardModel> Rewards { get; set; }
        public IList<string> Unlocks { get; set; }
        public IList<DialogModel> Story { get; set; }
    }

    public class RequireModel
    {
        public string Value { get; set; }
        public long? Amount { get; set; }
    }

    public class DialogModel
    {
        public string Speaker { get; set; }
        public string Mood { get; set; }
        public string Text { get; set; }
    }
}
