using Metaplay.Core.Model;

namespace GameLogic.Config.Map.Characters
{
    [MetaSerializable]
    public enum MapCharacterTransitionType
    {
        Undefined = 0,
        Fade = 1,
        Walk = 2
    }
}