using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Area
{
    public class MapSpotSource : IConfigItemSource<MapSpotInfo, MapSpotId>, IGameConfigSourceItem<MapSpotId, MapSpotInfo>, IHasGameConfigKey<MapSpotId>
    {
        private MapSpotId MapSpotId { get; set; }
        public AreaId Area { get; set; }
        private string TitleId { get; set; }
        public MapSpotId ConfigKey { get; }

        public MapSpotSource()
        {
        }
    }
}