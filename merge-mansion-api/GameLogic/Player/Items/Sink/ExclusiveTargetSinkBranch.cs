using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializable]
    public class ExclusiveTargetSinkBranch
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> RewardItem { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Target { get; set; }

        private ExclusiveTargetSinkBranch()
        {
        }

        public ExclusiveTargetSinkBranch(int itemId, int target, int rewardItemId)
        {
        }
    }
}