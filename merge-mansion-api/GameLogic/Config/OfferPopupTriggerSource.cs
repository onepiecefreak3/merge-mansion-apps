using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Config
{
    public class OfferPopupTriggerSource : IConfigItemSource<OfferPopupTrigger, OfferPopupTriggerId>, IGameConfigSourceItem<OfferPopupTriggerId, OfferPopupTrigger>, IHasGameConfigKey<OfferPopupTriggerId>
    {
        public OfferPopupTriggerId ConfigKey { get; set; }
        private int MaxTriggersPerSession { get; set; }
        private int MaxTriggersTotal { get; set; }
        private List<string> RequirementType { get; set; }
        private List<string> RequirementId { get; set; }
        private List<string> RequirementAmount { get; set; }
        private List<string> RequirementAux0 { get; set; }

        public OfferPopupTriggerSource()
        {
        }

        private bool ActivatesOfferGroup { get; set; }
        private List<string> TriggerPlacements { get; set; }
        private MetaDuration? MaxWaitTimerToPrompt { get; set; }
    }
}