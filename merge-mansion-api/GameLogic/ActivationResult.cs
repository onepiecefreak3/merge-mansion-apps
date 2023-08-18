using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum ActivationResult
    {
        Nothing = 0,
        ItemAdded = 1,
        ItemAddedAndRemoved = 2,
        Collected = 3
    }
}