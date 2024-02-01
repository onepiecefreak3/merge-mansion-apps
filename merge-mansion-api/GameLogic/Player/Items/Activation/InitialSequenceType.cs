using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Activation
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum InitialSequenceType
    {
        Global = 0,
        MergeItemInstance = 1
    }
}