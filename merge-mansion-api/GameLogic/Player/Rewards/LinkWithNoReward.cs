using Metaplay.Core.Model;
using System;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(9)]
    [MetaFormHidden]
    public class LinkWithNoReward : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Link { get; set; }

        public LinkWithNoReward()
        {
        }

        public LinkWithNoReward(string link)
        {
        }
    }
}