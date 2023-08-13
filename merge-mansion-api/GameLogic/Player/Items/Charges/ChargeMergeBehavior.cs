using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Charges
{
    [MetaSerializable]
    public enum ChargeMergeBehavior
    {
        Min = 0,
        Max = 1,
        Sum = 2
    }
}