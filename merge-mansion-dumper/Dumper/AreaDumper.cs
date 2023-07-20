using System.Collections.Generic;
using System.Linq;
using merge_mansion_dumper.Dumper.Base;
using merge_mansion_dumper.Dumper.Json;
using Metaplay.GameLogic.Area;
using Metaplay.GameLogic.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace merge_mansion_dumper.Dumper
{
    class AreaDumper : JsonDumper<IList<AreaInfo>>
    {
        public override IList<AreaInfo> Dump(SharedGameConfig config)
        {
            return config.Areas.EnumerateAll().Select(x => (AreaInfo)x.Value).ToList();
        }

        protected override JsonSerializerSettings CreateSettings(SharedGameConfig config)
        {
            return new JsonSerializerSettings(base.CreateSettings(config))
            {
                Converters =
                {
                    new MergeMansionJsonConverter(config, Output, false),
                    new StringEnumConverter()
                }
            };
        }
    }
}
