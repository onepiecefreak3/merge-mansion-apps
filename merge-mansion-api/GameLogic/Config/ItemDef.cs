using Metaplay.Core.Model;
using Game.Cloud.Config;
using System;
using GameLogic.Player.Items;

namespace GameLogic.Config
{
    [MetaSerializableDerived(2)]
    public class ItemDef : ConfigDefinition<int, ItemDefinition>
    {
        private ItemDef()
        {
        }

        public ItemDef(int key)
        {
        }
    }
}