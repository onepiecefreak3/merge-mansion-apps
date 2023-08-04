using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerExperimentsState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<PlayerExperimentId, PlayerExperimentsState.ExperimentAssignment> ExperimentGroupAssignment;
        public PlayerExperimentsState()
        {
        }

        [MetaSerializable]
        public struct ExperimentAssignment
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public ExperimentVariantId VariantId;
        }
    }
}