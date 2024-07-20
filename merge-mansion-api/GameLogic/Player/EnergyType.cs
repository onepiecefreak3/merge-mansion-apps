using Metaplay.Core.Model;

namespace GameLogic.Player
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum EnergyType
    {
        Default = 0,
        Secondary = 1,
        Tertiary = 2,
        None = 3,
        MysteryMachine = 4,
        MysteryMachineCoins = 5
    }
}