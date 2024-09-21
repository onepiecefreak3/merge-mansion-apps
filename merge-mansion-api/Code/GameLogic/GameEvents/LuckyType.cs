using GameLogic;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum LuckyType
    {
        Fish = 0,
        Birds = 1,
        GemMine = 2
    }
}