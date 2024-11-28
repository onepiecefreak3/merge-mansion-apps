using Metaplay.Core.Model;

namespace GameLogic.Random.ControlledRandom
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum RandomType
    {
        ControlledRandomMinMaxSequence = 0,
        Random = 1
    }
}