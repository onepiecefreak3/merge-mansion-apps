using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    public class ItemRewardsState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool RewardsClaimed { get; set; }

        public ItemRewardsState()
        {
        }
    }
}