using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Player.Items.Consumption.Logic;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Consumption
{
    public sealed class ConsumableFeatures
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
    }
}
