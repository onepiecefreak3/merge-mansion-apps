using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Area
{
    [MetaSerializable]
    public class LocationTravelInfo : IGameConfigData<LocationTravelId>, IGameConfigData, IHasGameConfigKey<LocationTravelId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private LocationTravelId Id { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public LocationId LocationId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public AreaId AreaId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string TitleLocalizationId { get; set; }

        public LocationTravelId ConfigKey => Id;

        public LocationTravelInfo()
        {
        }

        public LocationTravelInfo(LocationTravelId configKey, LocationId locationId, AreaId travelArea, string titleLocalizationId)
        {
        }
    }
}