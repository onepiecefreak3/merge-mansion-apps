using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Game.Cloud.Webshop
{
    [MetaSerializable]
    public class WebshopState
    {
        [ServerOnly]
        [MetaMember(1, (MetaMemberFlags)0)]
        public HashSet<WebshopPurchase> WebShopPurchaseHistory { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public HashSet<WebshopPurchase> PendingWebShopPurchases { get; set; }

        public WebshopState()
        {
        }
    }
}