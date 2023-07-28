using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(3)]
    [MetaSerializable]
    public class TransformCollectAction : ICollectAction
    {
        [MetaMember(1, 0)]
        public MetaRef<ItemDefinition> TransformsInto { get; set; }
    }
}
