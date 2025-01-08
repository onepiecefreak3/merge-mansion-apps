using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum RewardContainerItemType
    {
        None = 0,
        Item = 1,
        Currency = 2,
        Energy = 3,
        ItemForCollectibleBoardEvent = 4
    }
}