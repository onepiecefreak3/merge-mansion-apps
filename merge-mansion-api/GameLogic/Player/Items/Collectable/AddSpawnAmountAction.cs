using Metaplay.Core.Model;
using Metaplay.Core;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(10)]
    public class AddSpawnAmountAction : ICollectAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> SpawnerItemDefinition { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int CyclesToAdd { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public SideBoardEventId SideBoardEventIdToCheckMaxResourceItem { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int VisualFlyToItemId { get; set; }

        private AddSpawnAmountAction()
        {
        }

        public AddSpawnAmountAction(MetaRef<ItemDefinition> spawnerItemDefinition, int cyclesToAdd, SideBoardEventId sideBoardEventIdToCheckMaxResourceItem, int visualFlyToItemId)
        {
        }
    }
}