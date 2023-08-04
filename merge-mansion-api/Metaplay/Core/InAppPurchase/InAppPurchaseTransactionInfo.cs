using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public class InAppPurchaseTransactionInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public InAppPurchasePlatform Platform { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string TransactionId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public InAppProductId ProductId { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public InAppProductType ProductType { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string PlatformProductId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [PrettyPrint((PrettyPrintFlag)4)]
        public string Receipt { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string Signature { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public MetaTime PurchaseTime { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool HasMissingContent { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public bool AllowTestPurchases { get; set; }

        private InAppPurchaseTransactionInfo()
        {
        }

        private InAppPurchaseTransactionInfo(InAppPurchasePlatform platform, string transactionId, InAppProductId productId, InAppProductType productType, string platformProductId, string receipt, string signature, MetaTime purchaseTime, bool hasMissingContent, bool allowTestPurchases)
        {
        }
    }
}