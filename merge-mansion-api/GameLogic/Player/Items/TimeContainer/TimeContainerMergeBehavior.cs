using Metaplay.Core.Model;

namespace GameLogic.Player.Items.TimeContainer
{
    [MetaSerializable]
    public enum TimeContainerMergeBehavior
    {
        Min = 0,
        Max = 1,
        Sum = 2
    }
}