using Metaplay.GameLogic.Player.Items.Production;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Merging
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class SameItemsMergeMechanic : BaseMergeMechanic
    {
        [MetaMember(4)]
        public IItemProducer ResultProducer { get; set; }   // 0x18

        public override bool CanMerge(MergeItem sourceItem, MergeItem targetItem)
        {
            return sourceItem.Definition.ConfigKey == targetItem.Definition.ConfigKey;
        }

        protected override ItemDefinition GetMergeProduct(IPlayer player, MergeItem sourceItem, MergeItem targetItem)
        {
            return ResultProducer.Produce(player);
        }
    }
}
