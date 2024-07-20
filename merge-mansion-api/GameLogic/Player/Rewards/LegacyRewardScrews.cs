using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [Obsolete]
    [MetaSerializableDerived(4)]
    [MetaBlockedMembers(new int[] { 2 })]
    public class LegacyRewardScrews : PlayerReward
    {
        public LegacyRewardScrews()
        {
        }
    }
}