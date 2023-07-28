using GameLogic.Player.Items.Production;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializable]
    public class MergeFeatures
    {
        [MetaMember(1)]
        public IMergeMechanic Mechanic { get; set; }
        [MetaMember(2)]
        public IItemProducer AdditionalSpawnProducer { get; set; }
    }
}
