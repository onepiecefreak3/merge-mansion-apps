using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum FishRarity
    {
        Common = 0,
        Uncommon = 1,
        Rare = 2,
        VeryRare = 3,
        Epic = 4,
        Legendary = 5,
        Ultimate = 6,
        SuperUltimate = 7
    }
}