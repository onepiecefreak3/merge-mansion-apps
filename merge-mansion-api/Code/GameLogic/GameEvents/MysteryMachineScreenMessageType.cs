using GameLogic;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum MysteryMachineScreenMessageType
    {
        Text = 0,
        Sprite = 1
    }
}