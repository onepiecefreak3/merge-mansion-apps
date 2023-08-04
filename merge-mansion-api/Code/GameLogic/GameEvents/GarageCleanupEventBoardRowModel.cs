using Metaplay.Core.Model;
using System.Collections.Generic;
using GameLogic.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class GarageCleanupEventBoardRowModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<GarageCleanupEventBoardSlotModel> Slots;
        public GarageCleanupEventBoardRowModel()
        {
        }

        public GarageCleanupEventBoardRowModel(PlayerModel player, GarageCleanupBoardRowInfo rowInfo)
        {
        }
    }
}