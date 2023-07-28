using GameLogic.MergeChains;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(20)]
    [MetaSerializable]
    public class RewardLevelUpMergeChain : PlayerReward
    {
        [MetaMember(1, 0)]
        public MetaRef<MergeChainDefinition> MergeChainRef { get; set; }
    }
}
