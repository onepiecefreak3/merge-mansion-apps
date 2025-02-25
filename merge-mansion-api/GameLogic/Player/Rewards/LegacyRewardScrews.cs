using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaBlockedMembers(new int[] { 2 })]
    [MetaSerializableDerived(4)]
    [Obsolete]
    public class LegacyRewardScrews : PlayerReward
    {
        public LegacyRewardScrews()
        {
        }
    }
}