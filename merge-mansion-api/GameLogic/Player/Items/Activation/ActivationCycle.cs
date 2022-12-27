using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Activation
{
    [MetaSerializableDerived(1)]
    public class ActivationCycle : IActivationCycle
    {
        [MetaMember(1)]
        public MetaDuration ActivationDelay { get; set; }   // 0x10
        [MetaMember(2)]
        public MetaDuration FirstCycleStartDelay { get; set; }
        [MetaMember(3)]
        public MetaDuration DelayBetweenCycles { get; set; }    // 0x20
        [MetaMember(4)]
        public int HowManyAreGeneratedInCycle { get; set; } // 0x28
        [MetaMember(5)]
        public int ActivationAmountInCycle { get; set; }    // 0x2C
        [MetaMember(6)]
        public int HowManyCycles { get; set; }  // 0x30

        public int GetActivationAmountInCycle()
        {
            return ActivationAmountInCycle;
        }

        public int GetItemAmountInActivation()
        {
            return HowManyAreGeneratedInCycle;
        }

        public int HowManyAreGeneratedToStorage()
        {
            return HowManyAreGeneratedInCycle;
        }

        public MetaDuration GetActivationDelay()
        {
            return ActivationDelay;
        }

        public MetaDuration GetCycleDelay()
        {
            return DelayBetweenCycles;
        }

        public int InitialCycles()
        {
            return HowManyCycles;
        }
    }
}
