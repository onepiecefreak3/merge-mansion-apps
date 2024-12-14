using Metaplay.Core.Model;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum CardHiddenRarity
    {
        Common = 1,
        Rare = 2,
        Epic = 3
    }
}