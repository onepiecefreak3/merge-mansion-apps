using Metaplay.Core.Model;
using System.Collections.Generic;
using Merge;
using Metaplay.Core;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(24)]
    public class RewardSkipTime : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<MergeBoardId> MergeBoardIds { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration DurationToSkip { get; set; }

        public RewardSkipTime()
        {
        }

        public RewardSkipTime(List<MergeBoardId> mergeBoardIds, MetaDuration durationToSkip)
        {
        }
    }
}