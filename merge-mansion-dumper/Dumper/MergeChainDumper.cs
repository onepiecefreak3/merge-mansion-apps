using System.Collections.Generic;
using System.Linq;
using GameLogic.Config;
using GameLogic.MergeChains;
using merge_mansion_dumper.Dumper.Base;
using merge_mansion_dumper.Dumper.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace merge_mansion_dumper.Dumper
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
