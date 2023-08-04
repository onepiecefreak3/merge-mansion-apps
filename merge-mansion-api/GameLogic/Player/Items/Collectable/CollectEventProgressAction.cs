using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(4)]
    [MetaSerializable]
    public class CollectEventProgressAction : ICollectAction
    {
        [MetaMember(1, 0)]
        public int ProgressGiven { get; set; }

        private CollectEventProgressAction()
        {
        }

        public CollectEventProgressAction(int progressGiven)
        {
        }
    }
}