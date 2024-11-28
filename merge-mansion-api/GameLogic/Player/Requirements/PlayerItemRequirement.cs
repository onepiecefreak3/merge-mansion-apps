using System.Collections.Generic;
using System.Linq;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;
using Newtonsoft.Json;
using GameLogic.Config;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(1)]
    public class PlayerItemRequirement : PlayerRequirement
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        private List<int> ItemTypes { get; set; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [MetaOnMemberDeserializationFailure("FixRefs")]
        private List<ItemDef> ItemRefs { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Requirement { get; set; }
        public IReadOnlyCollection<int> Items => ItemTypes;

        public PlayerItemRequirement()
        {
        }

        public PlayerItemRequirement(int itemId, int requirement)
        {
        }

        public PlayerItemRequirement(IEnumerable<int> itemIds, int requirement)
        {
        }

        public PlayerItemRequirement(ItemDefinition definition, int amount)
        {
        }

        [JsonProperty("item")]
        public int? ItemKey { get; }
    }
}