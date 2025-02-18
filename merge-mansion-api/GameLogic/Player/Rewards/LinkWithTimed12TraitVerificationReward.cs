using Metaplay.Core;
using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(10)]
    public class LinkWithTimed12TraitVerificationReward : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Link { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public Currencies Currency { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public long RewardAmount { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaTime EndTime { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool ReadyToClaim { get; set; }

        public LinkWithTimed12TraitVerificationReward()
        {
        }
    }
}