using Code.GameLogic.Config;
using GameLogic.Area;
using Metaplay.Core.Config;
using System;

namespace GameLogic
{
    public class LocationTravelSource : IConfigItemSource<LocationTravelInfo, LocationTravelId>, IGameConfigSourceItem<LocationTravelId, LocationTravelInfo>, IHasGameConfigKey<LocationTravelId>
    {
        public LocationTravelId ConfigKey { get; set; }
        private LocationId TravelLocationId { get; set; }
        private AreaId TravelArea { get; set; }
        private string TitleLocalizationId { get; set; }

        public LocationTravelSource()
        {
        }
    }
}