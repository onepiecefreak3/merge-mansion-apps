using Metaplay.Core.Model;

namespace Game.Logic
{
    [MetaSerializable]
    public enum PlayerInventoryChangeEventType
    {
        Unknown = 0,
        Removed = 1,
        Added = 2,
        Replaced = 3,
        Collected = 4,
        TakeOut = 5
    }
}