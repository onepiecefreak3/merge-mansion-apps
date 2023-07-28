using GameLogic.Merge;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(6)]
    [MetaSerializable]
    public class RewardItem : PlayerReward
    {
        [MetaMember(1, 0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }
        [MetaMember(2, 0)]
        public int Amount { get; set; }
        [MetaMember(3, 0)]
        public bool FromSupport { get; set; }
        [MetaMember(4, 0)]
        public MergeBoardId MergeBoardId { get; set; }
	}
}
