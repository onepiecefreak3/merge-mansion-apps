using Metaplay;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace merge_mansion_cli.Models.Item
{
    class ItemModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public ItemCostModel Costs { get; set; }
        public ItemDropModel Drops { get; set; }
    }
}
