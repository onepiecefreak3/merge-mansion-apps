using Metaplay.Core.Model;

namespace GameLogic.CardCollection
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum CardsToRollFirst
    {
        Fixed = 0,
        Random = 1
    }
}