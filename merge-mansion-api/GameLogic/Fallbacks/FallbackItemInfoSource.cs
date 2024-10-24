using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Fallbacks
{
    public class FallbackItemInfoSource : IConfigItemSource<FallbackItemInfo, FallbackItemId>, IGameConfigSourceItem<FallbackItemId, FallbackItemInfo>, IHasGameConfigKey<FallbackItemId>
    {
        public FallbackItemId ConfigKey { get; set; }
        private string Item { get; set; }
        private string FallbackItem { get; set; }
        private string ExpiredItem { get; set; }

        public FallbackItemInfoSource()
        {
        }
    }
}