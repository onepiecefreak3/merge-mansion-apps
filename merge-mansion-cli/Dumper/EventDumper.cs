using System.Collections.Generic;
using System.Linq;
using merge_mansion_cli.Dumper.Base;
using merge_mansion_cli.Dumper.Json;
using Metaplay.GameLogic.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace merge_mansion_cli.Dumper
{
    class EventDumper : JsonDumper<IList<object>>
    {
        public override IList<object> Dump(SharedGameConfig config)
        {
            return config.BoardEvents.EnumerateAll().Select(x => x.Value).Concat(config.ProgressionEvents.EnumerateAll().Select(x => x.Value)).ToList();
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
