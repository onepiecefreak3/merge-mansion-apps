using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core;
using GameLogic.Player.Items;

namespace GameLogic.Fallbacks
{
    [MetaSerializable]
    public class FallbackItemInfo : IGameConfigData<FallbackItemId>, IGameConfigData, IHasGameConfigKey<FallbackItemId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public FallbackItemId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> FallbackItemRef { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ExpiredItemRef { get; set; }

        public FallbackItemInfo()
        {
        }

        public FallbackItemInfo(FallbackItemId fallbackItemId, MetaRef<ItemDefinition> itemRef, MetaRef<ItemDefinition> fallbackItemRef, MetaRef<ItemDefinition> expiredItemRef)
        {
        }
    }
}