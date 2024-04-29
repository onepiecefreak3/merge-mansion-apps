using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(13)]
    public class SpawnItemsIntoMysteryMachineCollectAction : ICollectAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int ItemCount { get; set; }

        private SpawnItemsIntoMysteryMachineCollectAction()
        {
        }

        public SpawnItemsIntoMysteryMachineCollectAction(int itemCount)
        {
        }
    }
}