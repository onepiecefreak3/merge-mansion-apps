using Metaplay.Core.Model;

namespace GameLogic.Random.ControlledRandom
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum RandomType
    {
        ControlledRandomMinMaxSequence = 0,
        Random = 1
    }
}