using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace GameLogic.Player.Items.Chest
{
    [MetaSerializable]
    public class ChestContext : IItemContext
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private TemporaryCardCollectionEventId TemporaryCardCollectionEventIdWhenChestWasGenerated { get; set; }

        public ChestContext()
        {
        }

        public ChestContext(IPlayer player)
        {
        }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool ShouldUpgradeCardPacks { get; set; }

        public ChestContext(IPlayer player, bool shouldUpgradeCardPacks)
        {
        }
    }
}