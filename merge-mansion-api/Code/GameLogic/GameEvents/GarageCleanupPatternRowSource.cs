using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class GarageCleanupPatternRowSource : IConfigItemSource<GarageCleanupPatternRowInfo, GarageCleanupPatternRowId>, IGameConfigSourceItem<GarageCleanupPatternRowId, GarageCleanupPatternRowInfo>, IHasGameConfigKey<GarageCleanupPatternRowId>
    {
        private GarageCleanupPatternRowId ConfigKey { get; set; }
        private int RowNumber { get; set; }
        private List<bool> ColumnNumber { get; set; }

        GarageCleanupPatternRowId Metaplay.Core.Config.IHasGameConfigKey<Code.GameLogic.GameEvents.GarageCleanupPatternRowId>.ConfigKey { get; }

        public GarageCleanupPatternRowSource()
        {
        }
    }
}