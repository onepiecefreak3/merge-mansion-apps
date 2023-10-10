using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Player.Items;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class GarageCleanupBoardRowInfo : IGameConfigData<GarageCleanupBoardRowId>, IGameConfigData, IGameConfigKey<GarageCleanupBoardRowId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GarageCleanupBoardRowId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<ItemDefinition>> Items { get; set; }

        public GarageCleanupBoardRowInfo()
        {
        }

        public GarageCleanupBoardRowInfo(GarageCleanupBoardRowId boardId, List<MetaRef<ItemDefinition>> items)
        {
        }
    }
}