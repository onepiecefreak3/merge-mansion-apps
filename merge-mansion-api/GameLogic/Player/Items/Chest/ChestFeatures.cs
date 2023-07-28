using GameLogic.Player.Items.Production;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Chest
{
    [MetaSerializable]
    public sealed class ChestFeatures
    {
        [MetaMember(1)]
        public bool IsChest { get; set; }
        [MetaMember(2)]
        public MetaDuration OpenDuration { get; set; }
        [MetaMember(3)]
        public int HowManyToRoll { get; set; }
        [MetaMember(4)]
        public IItemProducer LootProducer { get; set; }
        [MetaMember(5)]
        public string HintLocId { get; set; }
	}
}
