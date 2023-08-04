using Metaplay.Core.Model;

namespace GameLogic.Config.Map.Characters
{
    [MetaSerializable]
    public enum MapCharacterMode
    {
        None = 0,
        Map = 1,
        Dialogue = 2,
        Cinematic = 3
    }
}