using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(31)]
    public class RewardMysteryMachineProgressionEventProgress : PlayerReward
    {
        public static string PoolTag;
        public static string SkinName;
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ChainItemIndex { get; set; }

        public RewardMysteryMachineProgressionEventProgress()
        {
        }

        public RewardMysteryMachineProgressionEventProgress(int amount, int chainItemIndex, CurrencySource source)
        {
        }
    }
}