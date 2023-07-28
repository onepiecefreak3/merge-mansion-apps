using Metaplay.Core;

namespace GameLogic.Player.Items.Activation
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
