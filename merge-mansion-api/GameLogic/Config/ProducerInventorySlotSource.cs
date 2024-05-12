using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Config
{
    public class ProducerInventorySlotSource : IConfigItemSource<ProducerInventorySlotConfig, ProducerInventorySlotId>, IGameConfigSourceItem<ProducerInventorySlotId, ProducerInventorySlotConfig>, IHasGameConfigKey<ProducerInventorySlotId>
    {
        public ProducerInventorySlotId ConfigKey { get; set; }
        private List<string> TeaseRequirementType { get; set; }
        private List<string> TeaseRequirementId { get; set; }
        private List<string> TeaseRequirementAmount { get; set; }
        private List<string> TeaseRequirementAux0 { get; set; }
        private List<string> UnlockRequirementType { get; set; }
        private List<string> UnlockRequirementId { get; set; }
        private List<string> UnlockRequirementAmount { get; set; }
        private List<string> UnlockRequirementAux0 { get; set; }

        public ProducerInventorySlotSource()
        {
        }
    }
}