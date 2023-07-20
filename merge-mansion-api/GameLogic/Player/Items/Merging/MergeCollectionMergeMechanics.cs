using Metaplay.GameLogic.Merge;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Merging
{
    [MetaSerializableDerived(3)]
    [MetaSerializable]
    public class MergeCollectionMergeMechanics : BaseMergeMechanic
    {
        [MetaMember(4)]
        public MergeCollection MergeCollection { get; set; }    // 0x18

        public override bool CanMerge(MergeItem sourceItem, MergeItem targetItem)
        {
            return MergeCollection.ContainsPair((sourceItem.Definition.ConfigKey, targetItem.Definition.ConfigKey));
        }

        protected override ItemDefinition GetMergeProduct(IPlayer player, MergeItem sourceItem, MergeItem targetItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
