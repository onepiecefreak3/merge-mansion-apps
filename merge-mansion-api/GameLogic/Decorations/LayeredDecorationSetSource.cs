using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Decorations
{
    public class LayeredDecorationSetSource : IConfigItemSource<LayeredDecorationSetInfo, LayeredDecorationSetId>, IGameConfigSourceItem<LayeredDecorationSetId, LayeredDecorationSetInfo>, IHasGameConfigKey<LayeredDecorationSetId>
    {
        private LayeredDecorationSetId SetId { get; set; }
        private int RequiredProgressToOwn { get; set; }
        private string[] LayerInfo { get; set; }
        public LayeredDecorationSetId ConfigKey { get; }

        public LayeredDecorationSetSource()
        {
        }
    }
}