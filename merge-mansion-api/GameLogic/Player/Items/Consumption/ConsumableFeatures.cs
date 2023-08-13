using GameLogic.Player.Items.Consumption.Logic;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Consumption
{
    [MetaSerializable]
    public class ConsumableFeatures
    {
        [MetaMember(1, 0)]
        public bool IsConsumable { get; set; }

        [MetaMember(2, 0)]
        public IConsumptionLogic Logic { get; set; }

        [MetaMember(3, 0)]
        public bool AllowNearMatching { get; set; }

        [MetaMember(4, 0)]
        public bool DragSafeAreaEnabled { get; set; }

        [MetaMember(5, 0)]
        public int ItemStackCap { get; set; }

        public static ConsumableFeatures NoConsumable;
        private ConsumableFeatures()
        {
        }

        public ConsumableFeatures(bool isConsumableItem, IConsumptionLogic logic, bool allowNearMatching, bool dragSafeAreaEnabled, int itemStackCap)
        {
        }
    }
}