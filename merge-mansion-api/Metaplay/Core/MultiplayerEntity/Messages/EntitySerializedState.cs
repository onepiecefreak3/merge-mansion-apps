using System.Collections.Generic;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Metaplay.Core.Serialization;

namespace Metaplay.Core.MultiplayerEntity.Messages
{
    public struct EntitySerializedState
    {
        [MetaMember(1, 0)]
        public MetaSerialized<IMultiplayerModel> PublicState { get; set; } // 0x0

        [MetaMember(2, 0)]
        public MetaSerialized<MultiplayerMemberPrivateStateBase> MemberPrivateState { get; set; } // 0x10

        [MetaMember(3, 0)]
        public int CurrentOperation { get; set; } // 0x20

        [MetaMember(4, 0)]
        public int LogicVersion { get; set; } // 0x24

        [MetaMember(5, 0)]
        public ContentHash SharedGameConfigVersion { get; set; } // 0x28

        [MetaMember(6, 0)]
        public ContentHash SharedConfigPatchesVersion { get; set; } // 0x38

        [MetaMember(7, 0)]
        public EntityActiveExperiment[] ActiveExperiments { get; set; } // 0x48

        public EntitySerializedState(MetaSerialized<IMultiplayerModel> publicState, MetaSerialized<MultiplayerMemberPrivateStateBase> memberPrivateState, int currentOperation, int logicVersion, ContentHash sharedGameConfigVersion, ContentHash sharedConfigPatchesVersion, EntityActiveExperiment[] activeExperiments)
        {
            PublicState = publicState;
            MemberPrivateState = memberPrivateState;
            CurrentOperation = currentOperation;
            LogicVersion = logicVersion;
            SharedGameConfigVersion = sharedGameConfigVersion;
            SharedConfigPatchesVersion = sharedConfigPatchesVersion;
            ActiveExperiments = activeExperiments;
        }

        public Dictionary<PlayerExperimentId, ExperimentVariantId> TryGetNonEmptyExperimentAssignment()
        {
            if (ActiveExperiments.Length == 0)
                return null;
            var result = new Dictionary<PlayerExperimentId, ExperimentVariantId>();
            if (ActiveExperiments.Length < 1)
                return result;
            foreach (var ae in ActiveExperiments)
                result[ae.ExperimentId] = ae.VariantId;
            return result;
        }
    }
}