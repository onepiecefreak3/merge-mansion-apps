using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum ActivationPlacementStyle
    {
        NoActivation = 0,
        Near3x3 = 1,
        TotalRandomSpot = 2,
        NearRandomSpot = 3
    }
}