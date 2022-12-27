using Metaplay.GameLogic.Player.Items.Production;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Merging
{
    public class MergeFeatures
    {
        [MetaMember(1)]
        public IMergeMechanic Mechanic { get; set; }
        [MetaMember(2)]
        public IItemProducer AdditionalSpawnProducer { get; set; }
    }
}
