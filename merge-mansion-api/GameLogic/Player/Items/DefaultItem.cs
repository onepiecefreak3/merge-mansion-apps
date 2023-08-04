using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items
{
    [MetaSerializableDerived(1)]
    public class DefaultItem : IBoardItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemType { get; set; }

        public DefaultItem()
        {
        }

        public DefaultItem(int itemId, string itemType)
        {
        }
    }
}