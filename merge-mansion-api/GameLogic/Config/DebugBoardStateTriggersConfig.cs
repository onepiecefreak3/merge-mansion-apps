using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class DebugBoardStateTriggersConfig : IGameConfigData<DebugBoardStateTriggerId>, IGameConfigData, IHasGameConfigKey<DebugBoardStateTriggerId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DebugBoardStateTriggerId DebugBoardStateTriggerId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<DebugBoardStateId> DebugBoardStateIds { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<DebugFulfillUnlockRequirementsAreaId> DebugFulfillUnlockRequirementAreaIds { get; set; }
        public DebugBoardStateTriggerId ConfigKey { get; }

        public DebugBoardStateTriggersConfig()
        {
        }
    }
}