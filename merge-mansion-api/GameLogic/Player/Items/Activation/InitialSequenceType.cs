using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Activation
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum InitialSequenceType
    {
        Global = 0,
        MergeItemInstance = 1,
        BoardInstance = 2
    }
}