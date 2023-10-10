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
using System.Reflection;

namespace GameLogic.MergeChains
{
    [MetaSerializable]
    public class MergeChainDefinition : IGameConfigData<MergeChainId>, IGameConfigData, IGameConfigKey<MergeChainId>, IValidatable
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

        public ItemDefinition LastItem(int itemId)
        {
            var itemData = GetItemData(itemId);
            var isValid = IsValid(itemData);
            if (!isValid)
                return null;
            var chainElement = itemData.Item1.ElementAtOrDefault(itemData.Item1.Count - 1);
            return chainElement?.ElementAtOrDefault(itemId);
        }

        public bool IsLastItem(int itemId)
        {
            return LastItem(itemId)?.ConfigKey == itemId;
        }

        public ValueTuple<List<IMergeChainElement>, int, int> GetItemData(int itemId)
        {
            if (FallbackChain != null)
            {
                var itemData = GetItemData(FallbackChain, itemId);
                if (itemData != default)
                    return itemData;
            }

            return GetItemData(PrimaryChain, itemId);
        }

        private static (List<IMergeChainElement> chain, int chainIndex, int elementIndex) GetItemData(List<IMergeChainElement> chain, int itemId)
        {
            if (chain.Count <= 0)
                return (null, -1, -1);
            for (var i = 0; i < chain.Count; i++)
            {
                var item = chain[i];
                var index = item.IndexOf(itemId);
                if (index != -1)
                    return (chain, i, index);
            }

            return (null, -1, -1);
        }

        private bool IsValid(ValueTuple<List<IMergeChainElement>, int, int> itemData)
        {
            if (itemData.Item1 == null || itemData.Item1.Count < 1 || itemData.Item2 < 0)
                return false;
            return itemData is { Item2: > -1, Item3: > -1 } && itemData.Item2 < itemData.Item1.Count;
        }

        [MetaMember(10, (MetaMemberFlags)0)]
        public string OverrideMergeChainSfx { get; set; }
        public IEnumerable<ItemDefinition> DefaultItems => PrimaryChain.Select(x => x.First());
    }
}