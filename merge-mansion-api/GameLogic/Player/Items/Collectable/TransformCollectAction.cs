using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(3)]
    public class TransformCollectAction : ICollectAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> TransformsInto { get; set; }

        private TransformCollectAction()
        {
        }

        public TransformCollectAction(MetaRef<ItemDefinition> transformsInto)
        {
        }

        public TransformCollectAction(int itemId)
        {
        }
    }
}