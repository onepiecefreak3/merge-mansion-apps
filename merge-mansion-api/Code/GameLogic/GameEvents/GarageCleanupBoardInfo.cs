using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class GarageCleanupBoardInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GarageCleanupBoardId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<GarageCleanupBoardRowId> Rows { get; set; }

        public GarageCleanupBoardInfo()
        {
        }

        public GarageCleanupBoardInfo(GarageCleanupBoardId boardId, List<GarageCleanupBoardRowId> rows)
        {
        }
    }
}