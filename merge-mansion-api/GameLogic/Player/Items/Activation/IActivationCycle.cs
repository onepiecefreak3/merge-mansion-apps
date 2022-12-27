using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;

namespace Metaplay.GameLogic.Player.Items.Activation
{
    public interface IActivationCycle
    {
        int GetActivationAmountInCycle();
        int GetItemAmountInActivation();
        int HowManyAreGeneratedToStorage();
        MetaDuration GetActivationDelay();
        MetaDuration GetCycleDelay();
        int InitialCycles();
    }
}
