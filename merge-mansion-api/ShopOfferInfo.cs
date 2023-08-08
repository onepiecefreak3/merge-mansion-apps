using Metaplay.Core.Model;
using System;
using Metaplay.Core;
using GameLogic.Config;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

[MetaSerializable]
public class ShopOfferInfo
{
    [MetaMember(1, (MetaMemberFlags)0)]
    public ShopOfferId OfferId { get; set; }

    [MetaMember(2, (MetaMemberFlags)0)]
    public string DisplayName { get; set; }

    [MetaMember(3, (MetaMemberFlags)0)]
    public string Description { get; set; }

    [MetaMember(4, (MetaMemberFlags)0)]
    public MetaRef<InAppProductInfo> InAppProduct { get; set; }

    [MetaMember(5, (MetaMemberFlags)0)]
    public List<PlayerReward> Rewards { get; set; }

    [MetaMember(7, (MetaMemberFlags)0)]
    public int Priority { get; set; }

    [MetaMember(8, (MetaMemberFlags)0)]
    public bool Single { get; set; }

    [MetaMember(9, (MetaMemberFlags)0)]
    public string TitleLocId { get; set; }

    public ShopOfferInfo()
    {
    }
}