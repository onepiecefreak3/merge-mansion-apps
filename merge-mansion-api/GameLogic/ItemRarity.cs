using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum ItemRarity
    {
        Undefined = 0,
        Common = 1,
        Uncommon = 2,
        Rare = 3
    }
}