using GameLogic.MergeChains;
using Metaplay.Core;
using Metaplay.Core.Model;
using System.Runtime.Serialization;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(20)]
    public class RewardLevelUpMergeChain : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
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