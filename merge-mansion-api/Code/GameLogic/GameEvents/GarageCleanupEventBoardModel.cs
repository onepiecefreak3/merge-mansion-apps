using Metaplay.Core.Model;
using System.Collections.Generic;
using GameLogic.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class GarageCleanupEventBoardModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<GarageCleanupEventBoardRowModel> Rows;
        [MetaMember(2, (MetaMemberFlags)0)]
        public List<GarageCleanupPatternId> PatternsClaimed;
        public GarageCleanupEventBoardModel()
        {
        }

        public GarageCleanupEventBoardModel(PlayerModel player, GarageCleanupBoardInfo boardInfo)
        {
        }
    }
}