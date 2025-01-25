using Metaplay.Core.Model;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum BoardActionType
    {
        None = 0,
        Autospawn = 1,
        Shop = 2,
        EnergyMode = 3,
        Sell = 4
    }
}