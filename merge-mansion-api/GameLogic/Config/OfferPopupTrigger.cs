using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using Code.GameLogic.Config;
using Metaplay.Core;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class OfferPopupTrigger : IGameConfigData<OfferPopupTriggerId>, IGameConfigData, IHasGameConfigKey<OfferPopupTriggerId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public OfferPopupTriggerId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int MaxTriggersPerSession { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int MaxTriggersTotal { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<PlayerRequirement> TriggerRequirements { get; set; }

        public OfferPopupTrigger()
        {
        }

        public OfferPopupTrigger(OfferPopupTriggerId configKey, int maxTriggersPerSession, int maxTriggersTotal, List<PlayerRequirement> triggerRequirements)
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        private Dictionary<OfferPopupTriggerPlacementType, List<string>> TriggerPlacements { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public bool ActivatesOfferGroup { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaDuration? MaxWaitTimerToPrompt { get; set; }

        public OfferPopupTrigger(OfferPopupTriggerId configKey, int maxTriggersPerSession, int maxTriggersTotal, List<PlayerRequirement> triggerRequirements, bool activatesOfferGroup, Dictionary<OfferPopupTriggerPlacementType, List<string>> triggerPlacements, MetaDuration? maxWaitTimerToPrompt)
        {
        }

        public static string ShowMethodBadgeClicked { get; }
        public static string ShowMethodManualActivation { get; }
        public static string ShowMethodShopPopup { get; }
        public static string ShowMethodAppLoading { get; }
        public static string ShowMethodLobbyReturn { get; }
        public static string ShowMethodWebShop { get; }
        public static string ShowMethodMergeBoardEnter { get; }
        public static string ShowMethodPopupOpen { get; }
        public static string ShowMethodPopupClose { get; }
        public static string ShowMethodPendingTimeExtensionOffer { get; }
        public static string ShowMethodEventPassPurchaseStyleDefault { get; }
        public static string ShowMethodEventPassPurchaseStyleRewards { get; }
        public static string ShowMethodExtendGameEvent { get; }
        public static string ShowMethodPromptOpenShopNotYetOpened { get; }
        public static string ShowMethodShopHasARefreshedSection { get; }
        public static string ShowMethodPromptForFreeOffer { get; }
        public static string ShowMethodEventPassPurchaseClicked { get; }
        public static string ShowMethodMysteryMachineOutOfCurrencyConfirmation { get; }
    }
}