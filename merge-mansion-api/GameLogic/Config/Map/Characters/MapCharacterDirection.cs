using Metaplay.Core.Model;

namespace GameLogic.Config.Map.Characters
{
    [MetaSerializable]
    public enum MapCharacterDirection
    {
        Undefined = 0,
        NorthEast = 1,
        SouthEast = 2,
        SouthWest = 3,
        NorthWest = 4
    }
}