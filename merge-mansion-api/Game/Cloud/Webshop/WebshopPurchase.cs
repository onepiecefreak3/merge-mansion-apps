using Metaplay.Core.Model;
using System;
using Metaplay.Core;
using System.Collections.Generic;

namespace Game.Cloud.Webshop
{
    [MetaSerializable]
    public class WebshopPurchase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string PurchaseId;
        [MetaMember(2, (MetaMemberFlags)0)]
        [ServerOnly]
        public string OrderNumber;
        [ServerOnly]
        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaTime PurchaseTime;
        [ServerOnly]
        [MetaMember(4, (MetaMemberFlags)0)]
        public WebshopType Type;
        [MetaMember(5, (MetaMemberFlags)0)]
        public List<WebshopItem> Items;
        [ServerOnly]
        [MetaMember(6, (MetaMemberFlags)0)]
        public string RefundId;
        [ServerOnly]
        [MetaMember(7, (MetaMemberFlags)0)]
        public bool RefundProcessed;
        [ServerOnly]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string Currency;
        public WebshopPurchase()
        {
        }
    }
}