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
            var boards = config.BoardEvents.EnumerateAll().Select(x => x.Value);
            var progressions = config.ProgressionEvents.EnumerateAll().Select(x => x.Value);
            return boards.Concat(progressions).ToArray();
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
