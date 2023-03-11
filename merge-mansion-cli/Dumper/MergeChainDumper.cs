using System.Collections.Generic;
using System.Linq;
using merge_mansion_cli.Dumper.Base;
using merge_mansion_cli.Dumper.Json;
using Metaplay.GameLogic.Config;
using Metaplay.GameLogic.MergeChains;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace merge_mansion_cli.Dumper
{
    class MergeChainDumper : JsonDumper<IList<MergeChainDefinition>>
    {
        private readonly bool _dropsAsPercent;

        public MergeChainDumper(bool dropsAsPercent)
        {
            _dropsAsPercent = dropsAsPercent;
        }

        public override IList<MergeChainDefinition> Dump(SharedGameConfig config)
        {
            return config.MergeChains.EnumerateAll().Select(x => (MergeChainDefinition)x.Value).ToList();
        }

        protected override JsonSerializerSettings CreateSettings(SharedGameConfig config)
        {
            return new JsonSerializerSettings(base.CreateSettings(config))
            {
                Converters =
                {
                    new MergeMansionJsonConverter(config, Output, _dropsAsPercent),
                    new StringEnumConverter()
                }
            };
        }
    }
}
