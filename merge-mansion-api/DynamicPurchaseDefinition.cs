using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Player.Rewards;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay
{
    [MetaSerializable]
    public sealed class DynamicPurchaseDefinition : IGameConfigData<ShopItemId>
    {
        [MetaMember(1)]
        public ShopItemId ItemId { get; set; }
        [MetaMember(2)]
        public List<PlayerReward> Rewards { get; set; }

        public ShopItemId ConfigKey => ItemId;
    }
}
