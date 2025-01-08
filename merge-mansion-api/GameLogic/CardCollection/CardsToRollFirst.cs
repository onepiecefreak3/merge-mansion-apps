using Metaplay.Core.Model;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum CardsToRollFirst
    {
        Fixed = 0,
        Random = 1
    }
}