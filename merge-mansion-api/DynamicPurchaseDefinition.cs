using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

[MetaSerializable]
public sealed class DynamicPurchaseDefinition : IGameConfigData<ShopItemId>
{
    [MetaMember(1)]
    public ShopItemId ItemId { get; set; }
    [MetaMember(2)]
    public List<PlayerReward> Rewards { get; set; }

    public ShopItemId ConfigKey => ItemId;
}