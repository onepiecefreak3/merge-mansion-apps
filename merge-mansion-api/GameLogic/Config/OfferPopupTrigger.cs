using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Requirements;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class OfferPopupTrigger : IGameConfigData<OfferPopupTriggerId>, IGameConfigData, IHasGameConfigKey<OfferPopupTriggerId>
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
    }
}