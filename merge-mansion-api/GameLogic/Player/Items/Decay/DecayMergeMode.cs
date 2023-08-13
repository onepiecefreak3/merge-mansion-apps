using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Decay
{
    [MetaSerializable]
    public enum DecayMergeMode
    {
        Reset = 0,
        Min = 1,
        Average = 2,
        Max = 3,
        Sum = 4
    }
}