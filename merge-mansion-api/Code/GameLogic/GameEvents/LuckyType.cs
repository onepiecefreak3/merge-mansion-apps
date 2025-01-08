using GameLogic;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum LuckyType
    {
        Fish = 0,
        Birds = 1,
        GemMine = 2,
        TheGreatEscape = 3
    }
}