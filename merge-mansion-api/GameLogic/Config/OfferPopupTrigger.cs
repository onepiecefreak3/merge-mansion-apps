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

        public static string ShowMethodBadgeClicked;
        public static string ShowMethodManualActivation;
        public static string ShowMethodShopPopup;
        public static string ShowMethodAppLoading;
        public static string ShowMethodLobbyReturn;
        public static string ShowMethodWebShop;
        public static string ShowMethodMergeBoardEnter;
        public static string ShowMethodPopupOpen;
        public static string ShowMethodPopupClose;
        [MetaMember(5, (MetaMemberFlags)0)]
        private Dictionary<OfferPopupTriggerPlacementType, List<string>> TriggerPlacements { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public bool ActivatesOfferGroup { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaDuration? MaxWaitTimerToPrompt { get; set; }

        public OfferPopupTrigger(OfferPopupTriggerId configKey, int maxTriggersPerSession, int maxTriggersTotal, List<PlayerRequirement> triggerRequirements, bool activatesOfferGroup, Dictionary<OfferPopupTriggerPlacementType, List<string>> triggerPlacements, MetaDuration? maxWaitTimerToPrompt)
        {
        }
    }
}