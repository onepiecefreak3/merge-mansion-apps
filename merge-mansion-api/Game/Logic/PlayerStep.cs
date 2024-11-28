using GameLogic;
using Metaplay.Core.Model;

namespace Game.Logic
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum PlayerStep
    {
        None = 0,
        ShowHardTaskTooltip = 1
    }
}