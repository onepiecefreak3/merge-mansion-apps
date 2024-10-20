using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaBlockedMembers(new int[] { 2 })]
    [Obsolete]
    [MetaSerializableDerived(4)]
    public class LegacyRewardScrews : PlayerReward
    {
        public LegacyRewardScrews()
        {
        }
    }
}