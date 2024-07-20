using Metaplay.Core.Model;
using Metaplay.Core.Serialization;
using System;
using Metaplay.Core.Math;

namespace Metaplay.Core.InAppPurchase
{
    [MetaReservedMembers(18, 100)]
    [MetaDeserializationConvertFromIntegrationImplementation]
    [MetaReservedMembers(1, 12)]
    [MetaReservedMembers(13, 17)]
    [MetaSerializable]
    public abstract class InAppPurchaseEvent : IMetaIntegrationConstructible<InAppPurchaseEvent>, IMetaIntegration<InAppPurchaseEvent>, IMetaIntegration, IMetaIntegrationConstructible, IRequireSingleConcreteType
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public InAppPurchasePlatform Platform { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string TransactionId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public InAppProductId ProductId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string PlatformProductId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [PrettyPrint((PrettyPrintFlag)4)]
        public string Receipt { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string Signature { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public InAppPurchaseStatus Status { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public string OrderId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool IsDuplicateTransaction { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        [ServerOnly]
        public int NumValidationsStarted { get; set; }

        [ServerOnly]
        [MetaMember(19, (MetaMemberFlags)0)]
        public int NumValidationTransientErrors { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public MetaTime PurchaseTime { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public F64 ReferencePrice { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public MetaTime ClaimTime { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public DynamicPurchaseContent DynamicContent { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        public bool HasMissingContent { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public ResolvedPurchaseContentBase ResolvedContent { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public ResolvedPurchaseMetaRewards ResolvedDynamicContent { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        public string GameProductAnalyticsId { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public MetaSerialized<PurchaseAnalyticsContext> GamePurchaseAnalyticsContext { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        public SubscriptionQueryResult SubscriptionQueryResult { get; set; }

        [MetaMember(24, (MetaMemberFlags)0)]
        public string OriginalTransactionIdIfDifferentFromTransactionId { get; set; }
        public string OriginalTransactionId { get; }

        [MetaMember(25, (MetaMemberFlags)0)]
        public InAppPurchasePaymentType? PaymentType { get; set; }

        protected InAppPurchaseEvent()
        {
        }
    }
}