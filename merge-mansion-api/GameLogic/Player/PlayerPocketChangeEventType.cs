using Metaplay.Core.Model;

namespace GameLogic.Player
{
    [MetaSerializable]
    public enum PlayerPocketChangeEventType
    {
        Removed = 1,
        Added = 2,
        None = 3
    }
}