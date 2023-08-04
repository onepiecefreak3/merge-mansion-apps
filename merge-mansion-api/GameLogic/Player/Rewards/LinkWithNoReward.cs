using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(9)]
    [MetaSerializable]
    public class LinkWithNoReward : PlayerReward
    {
        [MetaMember(1, 0)]
        public string Link { get; set; }

        public LinkWithNoReward()
        {
        }

        public LinkWithNoReward(string link)
        {
        }
    }
}