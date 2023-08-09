using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum BoostAreaStyle
    {
        NoBoost = 0,
        NearHorizontalAndVertical = 1,
        Near3x3 = 2,
        Near3x3Bigger = 3
    }
}