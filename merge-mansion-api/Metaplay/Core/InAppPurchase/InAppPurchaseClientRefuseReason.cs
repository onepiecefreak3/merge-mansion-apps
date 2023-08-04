using Metaplay.Core.Model;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public enum InAppPurchaseClientRefuseReason
    {
        Unknown = 0,
        CompletionActionFailed = 1,
        UnityUserCancelled = 2,
        UnityPurchasingUnavailable = 3,
        UnityExistingPurchasePending = 4,
        UnityProductUnavailable = 5,
        UnitySignatureInvalid = 6,
        UnityPaymentDeclined = 7,
        UnityDuplicateTransaction = 8
    }
}