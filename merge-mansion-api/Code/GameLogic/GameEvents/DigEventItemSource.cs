using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    public class DigEventItemSource : IConfigItemSource<DigEventItemInfo, DigEventItemId>, IGameConfigSourceItem<DigEventItemId, DigEventItemInfo>, IHasGameConfigKey<DigEventItemId>
    {
        public DigEventItemId ConfigKey { get; set; }
        private string AssetId { get; set; }
        private bool GoesMuseum { get; set; }
        private int MuseumItemWidth { get; set; }
        private int MuseumItemHeight { get; set; }
        private bool CanBeShiny { get; set; }
        private DigEventItemId ShinyReplaces { get; set; }
        private string Coordinates { get; set; }
        private int Weight { get; set; }
        private MuseumItemRotation MuseumItemRotation { get; set; }

        public DigEventItemSource()
        {
        }
    }
}