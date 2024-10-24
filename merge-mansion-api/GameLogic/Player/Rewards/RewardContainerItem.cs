using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializable]
    public class RewardContainerItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public RewardContainerItemType Type { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Item { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string ItemAux0 { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string ItemAux1 { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int MinAmount { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int MaxAmount { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public int BatchAmount { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public int Weight { get; set; }

        public RewardContainerItem()
        {
        }

        public RewardContainerItem(RewardContainerItemType type, string item, string itemAux0, string itemAux1, int minAmount, int maxAmount, int? batchAmount, int weight)
        {
        }
    }
}