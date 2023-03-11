using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.MergeChains;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(20)]
    public class RewardLevelUpMergeChain : PlayerReward
    {
        [MetaMember(1, 0)]
        public MetaRef<MergeChainDefinition> MergeChainRef { get; set; }
    }
}
