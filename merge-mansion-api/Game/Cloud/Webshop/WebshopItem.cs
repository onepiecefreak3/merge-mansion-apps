using Metaplay.Core.Model;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using System;
using Metaplay.Core;
using Metaplay.Core.InAppPurchase;

namespace Game.Cloud.Webshop
{
    [MetaSerializable]
    [MetaReservedMembers(100, 110)]
    public abstract class WebshopItem
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public bool IsConsumed { get; set; }

        [ServerOnly]
        [MetaMember(102, (MetaMemberFlags)0)]
        public int ReferencePrice { get; set; }

        [ServerOnly]
        [MetaMember(103, (MetaMemberFlags)0)]
        public string ReferenceCurrency { get; set; }

        [MetaMember(104, (MetaMemberFlags)0)]
        [ServerOnly]
        public MetaTime? ConsumeTime { get; set; }

        [MetaMember(105, (MetaMemberFlags)0)]
        [ServerOnly]
        public int Price { get; set; }

        [ServerOnly]
        [MetaMember(106, (MetaMemberFlags)0)]
        public string Sku { get; set; }
        public virtual bool ShouldEarlyConsume { get; }
        public abstract InAppProductId ProductId { get; }

        protected WebshopItem()
        {
        }
    }
}