using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace GameLogic.Config
{
    public class ManuallyActivatedOfferGroupSource : IConfigItemSource<ManuallyActivatedOfferGroupInfo, ManuallyActivatedOfferGroupId>, IGameConfigSourceItem<ManuallyActivatedOfferGroupId, ManuallyActivatedOfferGroupInfo>, IHasGameConfigKey<ManuallyActivatedOfferGroupId>
    {
        public ManuallyActivatedOfferGroupId ConfigKey { get; set; }
        private int MaxTriggeredPerSession { get; set; }
        private List<string> ActivationRequirementType { get; set; }
        private List<string> ActivationRequirementId { get; set; }
        private List<string> ActivationRequirementAmount { get; set; }
        private List<string> ActivationRequirementAux0 { get; set; }

        public ManuallyActivatedOfferGroupSource()
        {
        }
    }
}