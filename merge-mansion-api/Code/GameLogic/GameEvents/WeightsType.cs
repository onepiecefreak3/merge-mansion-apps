using GameLogic;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum WeightsType
    {
        Heat = 0,
        Clicks = 1
    }
}