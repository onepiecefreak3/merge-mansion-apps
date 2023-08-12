using GameLogic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace merge_mansion_dumper.Models.Item
{
    class ItemModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemTypeConstant Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public ItemCostModel Costs { get; set; }
        public ItemDropModel Drops { get; set; }
    }
}
