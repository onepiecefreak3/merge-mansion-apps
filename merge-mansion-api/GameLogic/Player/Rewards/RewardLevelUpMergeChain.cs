using GameLogic.MergeChains;
using Metaplay.Core;
using Metaplay.Core.Model;
using System.Runtime.Serialization;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(20)]
    [MetaSerializable]
    public class RewardLevelUpMergeChain : PlayerReward
    {
        [MetaMember(1, 0)]
        public MetaRef<MergeChainDefinition> MergeChainRef { get; set; }

        [IgnoreDataMember]
        public MergeChainDefinition MergeChain { get; }

        public RewardLevelUpMergeChain()
        {
        }

        public RewardLevelUpMergeChain(MergeChainId mergeChainId)
        {
        }
    }
}