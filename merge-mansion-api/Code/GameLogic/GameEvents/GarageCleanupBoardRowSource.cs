using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class GarageCleanupBoardRowSource : IConfigItemSource<GarageCleanupBoardRowInfo, GarageCleanupBoardRowId>, IGameConfigSourceItem<GarageCleanupBoardRowId, GarageCleanupBoardRowInfo>, IHasGameConfigKey<GarageCleanupBoardRowId>
    {
        public GarageCleanupBoardId ConfigKey { get; set; }
        private int RowNumber { get; set; }
        private List<string> ColumnNumber { get; set; }

        GarageCleanupBoardRowId Metaplay.Core.Config.IHasGameConfigKey<Code.GameLogic.GameEvents.GarageCleanupBoardRowId>.ConfigKey { get; }

        public GarageCleanupBoardRowSource()
        {
        }
    }
}