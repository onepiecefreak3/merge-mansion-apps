using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class GarageCleanupPatternRowInfo : IGameConfigData<GarageCleanupPatternRowId>, IGameConfigData, IHasGameConfigKey<GarageCleanupPatternRowId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GarageCleanupPatternRowId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<bool> Pattern { get; set; }

        public GarageCleanupPatternRowInfo()
        {
        }

        public GarageCleanupPatternRowInfo(GarageCleanupPatternRowId boardId, List<bool> pattern)
        {
        }
    }
}