using Metaplay.Core.Model;

namespace GameLogic.Player.Actions.Development
{
    [MetaSerializable]
    public enum CheatItemActivationState
    {
        Empty = 0,
        EmptyButSoonRefilled = 1,
        AlmostEmpty = 2,
        FullyFilled = 3
    }
}