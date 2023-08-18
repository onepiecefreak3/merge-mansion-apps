using System;

namespace Metaplay.Core.Model
{
    public class MetaActionResult
    {
        public static MetaActionResult Success;
        public static MetaActionResult UnknownError;
        public static MetaActionResult InvalidActionType;
        public static MetaActionResult InvalidLanguage;
        public static MetaActionResult InvalidMailId;
        public static MetaActionResult InvalidMail;
        public static MetaActionResult MailAlreadyConsumed;
        public static MetaActionResult MailNotConsumed;
        public static MetaActionResult DuplicateMailId;
        public static MetaActionResult InvalidInAppTransactionId;
        public static MetaActionResult InvalidInAppTransactionState;
        public static MetaActionResult InvalidInAppPurchaseEvent;
        public static MetaActionResult InvalidInAppProductId;
        public static MetaActionResult TooManyPendingInAppPurchases;
        public static MetaActionResult InvalidInAppPlatformProductId;
        public static MetaActionResult InvalidInAppPlatform;
        public static MetaActionResult InvalidDynamicInAppPurchaseStatus;
        public static MetaActionResult InvalidNonDynamicInAppPurchaseStatus;
        public static MetaActionResult CannotSetPendingDynamicPurchase;
        public static MetaActionResult NoSuchSubscription;
        public static MetaActionResult ExistingSubscriptionStateIsNewer;
        public static MetaActionResult InvalidFirebaseMessagingToken;
        public static MetaActionResult NoSessionDeviceId;
        public static MetaActionResult MetaOfferGroupHasNoState;
        public static MetaActionResult MetaOfferNotInGroup;
        public static MetaActionResult MetaOfferNotPurchasable;
        public static MetaActionResult MetaOfferDoesNotHaveInAppProduct;
        public static MetaActionResult NoSuchGuildMember;
        public static MetaActionResult GuildOperationNotPermitted;
        public static MetaActionResult GuildOperationStale;
        public static MetaActionResult AlreadyHasNft;
        public static MetaActionResult HasNoSuchNft;
        public static MetaActionResult NftTransactionAlreadyPending;
        public static MetaActionResult NoSuchDivisionParticipant;
        public static MetaActionResult NoSuchDivision;
        public static MetaActionResult InvalidDivisionState;
        public static MetaActionResult RewardAlreadyClaimed;
        public static MetaActionResult DuplicateDivisionHistoryEntry;
        public static MetaActionResult InvalidDivisionHistoryEntry;
        public string Name { get; set; }

        public MetaActionResult(string name)
        {
        }
    }
}