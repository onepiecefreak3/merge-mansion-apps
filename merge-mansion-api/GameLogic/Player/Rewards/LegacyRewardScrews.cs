using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(4)]
    [Obsolete]
    [MetaBlockedMembers(new int[] { 2 })]
    public class LegacyRewardScrews : PlayerReward
    {
        public LegacyRewardScrews()
        {
        }
    }
}