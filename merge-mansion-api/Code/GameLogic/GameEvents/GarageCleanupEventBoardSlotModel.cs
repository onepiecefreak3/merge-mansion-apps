using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class GarageCleanupEventBoardSlotModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsFilled;
        public GarageCleanupEventBoardSlotModel()
        {
        }
    }
}