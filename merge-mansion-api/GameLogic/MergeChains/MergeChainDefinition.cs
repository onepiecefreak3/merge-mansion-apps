using System.Collections.Generic;
using GameLogic.Codex;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Code.GameLogic.Config;
using System;
using System.Linq;
using System.Runtime.Serialization;
using GameLogic.Player.Items;

namespace GameLogic.MergeChains
{
    [MetaSerializable]
    public class MergeChainDefinition : IGameConfigData<MergeChainId>, IGameConfigData, IValidatable
    {
        private static HashSet<Type> allowedTypes = new()
        {
            typeof(int),
            typeof(int[])
        };
        [MetaMember(1, 0)]
        public MergeChainId ConfigKey { get; set; }

        [MetaMember(2, 0)]
        public List<IMergeChainElement> PrimaryChain { get; set; }

        [MetaMember(3, 0)]
        public List<IMergeChainElement> FallbackChain { get; set; }

        [MetaMember(4, 0)]
        public MetaRef<CodexCategoryInfo> CodexCategory { get; set; }

        [MetaMember(5, 0)]
        public MetaRef<CodexDiscoveryRewardInfo> DiscoveryRewardRef { get; set; }

        [MetaMember(6, 0)]
        public string CompletionSfx { get; set; }

        [MetaMember(7, 0)]
        public int? InitialLevel { get; set; }

        [MetaMember(8, 0)]
        public int? UnsellableUntilPlayerLevel { get; set; }

        [MetaMember(9, 0)]
        public int? ShowSellConfirmationUntilPlayerLevel { get; set; }
        public int Length => PrimaryChain.Count;
        public int FallbackLength => FallbackChain?.Count ?? 0;

        [IgnoreDataMember]
        public int Item => GetItemDefinition(0).ConfigKey;
        public IEnumerable<int> ItemTypes => PrimaryChain.Select(x => x.First().ConfigKey);
        public IEnumerable<ItemDefinition> Items => PrimaryChain.Select(x => x.First());

        public MergeChainDefinition()
        {
        }

        public MergeChainDefinition(MergeChainId chainId, object[] items)
        {
        }

        public MergeChainDefinition(MergeChainId chainId, object[] items, object[] fallbacks)
        {
        }

        public MergeChainDefinition(MergeChainId configKey, IEnumerable<IMergeChainElement> primaryChain, IEnumerable<IMergeChainElement> fallbackChain, int? initialLevel, int? unsellableUntilPlayerLevel, int? showSellConfirmationUntilPlayerLevel)
        {
        }

        public ItemDefinition GetItemDefinition(int zeroBasedIndex)
        {
            var chainItem = PrimaryChain[zeroBasedIndex];
            return chainItem.First();
        }

        public int Last()
        {
            return ItemTypes.Last();
        }
    }
}