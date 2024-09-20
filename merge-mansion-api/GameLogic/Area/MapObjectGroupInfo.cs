using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Area
{
    [MetaSerializable]
    public class MapObjectGroupInfo : IGameConfigData<MapObjectGroupId>, IGameConfigData, IHasGameConfigKey<MapObjectGroupId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MapObjectGroupId MapObjectGroupId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<string> UniqueIds { get; set; }
        public MapObjectGroupId ConfigKey => MapObjectGroupId;

        public MapObjectGroupInfo()
        {
        }

        public MapObjectGroupInfo(MapObjectGroupId mapObjectGroupId, List<string> uniqueIds)
        {
        }
    }
}