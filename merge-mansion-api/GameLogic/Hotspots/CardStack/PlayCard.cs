using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Player.Items;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Hotspots.CardStack
{
    [MetaSerializable]
    public class PlayCard
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<ItemDefinition> ItemRef { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Row { get; set; }

        [IgnoreDataMember]
        public ItemDefinition Item { get; }

        public PlayCard()
        {
        }

        public PlayCard(int itemId, int row)
        {
        }
    }
}