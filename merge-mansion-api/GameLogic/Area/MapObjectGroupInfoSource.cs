using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Area
{
    public class MapObjectGroupInfoSource : IConfigItemSource<MapObjectGroupInfo, MapObjectGroupId>, IGameConfigSourceItem<MapObjectGroupId, MapObjectGroupInfo>, IHasGameConfigKey<MapObjectGroupId>
    {
        public MapObjectGroupId ConfigKey { get; set; }
        private List<string> UniqueIds { get; set; }

        public MapObjectGroupInfoSource()
        {
        }
    }
}