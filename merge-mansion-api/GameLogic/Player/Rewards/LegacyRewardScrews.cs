using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(4)]
    [MetaBlockedMembers(new int[] { 2 })]
    [Obsolete]
    public class LegacyRewardScrews : PlayerReward
    {
        public LegacyRewardScrews()
        {
        }
    }
}