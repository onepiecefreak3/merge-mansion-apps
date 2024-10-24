using GameLogic;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum MysteryMachineScreenMessageType
    {
        Text = 0,
        Sprite = 1
    }
}