using Metaplay.Core.Model;

namespace GameLogic
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum ItemRarity
    {
        Undefined = 0,
        Common = 1,
        Uncommon = 2,
        Rare = 3
    }
}