using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum RewardContainerItemType
    {
        None = 0,
        Item = 1,
        Currency = 2,
        Energy = 3,
        ItemForCollectibleBoardEvent = 4
    }
}