using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Activation
{
    [MetaSerializable]
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