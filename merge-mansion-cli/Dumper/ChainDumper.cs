using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using merge_mansion_cli.Models.Item;
using Metaplay;
using Metaplay.GameLogic.Config;
using Metaplay.GameLogic.MergeChains;
using Metaplay.GameLogic.Player.Items;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Localization;

namespace merge_mansion_cli.Dumper
{
    class ChainDumper : JsonDumper<IList<ChainModel>>
    {
        private readonly bool _dropsAsPercent;

        public ChainDumper(bool dropsAsPercent)
        {
            _dropsAsPercent = dropsAsPercent;
        }

        protected override IList<ChainModel> Dump(SharedGameConfig config)
        {
            return config.MergeChains.EnumerateAll().Select(x => GetChainModel((MergeChainDefinition)x.Value, config)).ToArray();
        }

        private ChainModel GetChainModel(MergeChainDefinition chain, SharedGameConfig config)
        {
            return new ChainModel
            {
                Id = chain.ConfigKey.Value,
                Name = LocMan.GetItemCategoryName(chain.ConfigKey),
                Items = GetChainItems(chain, config)
            };
        }

        private IList<ItemModel> GetChainItems(MergeChainDefinition mergeChain, SharedGameConfig config)
        {
            var res = new List<ItemModel>();

            foreach (var item in mergeChain.PrimaryChain)
            {
                ItemDefinition itemDef;
                switch (item)
                {
                    case SingleMergeChainElement single:
                        itemDef = single.Item.CreateResolved(config).Ref;
                        break;

                    case ListMergeChainElement list:
                        itemDef = list.Items.First().CreateResolved(config).Ref;
                        break;

                    default:
                        continue;
                }

                if (!Enum.IsDefined(itemDef.ConfigKey))
                {
                    Output.Warning("ItemType {0} unknown", itemDef.ConfigKey);
                    continue;
                }

                res.Add(GetItemModel(itemDef));
            }

            return res;
        }

        private ItemModel GetItemModel(ItemDefinition item)
        {
            return new ItemModel
            {
                Id = item.ConfigKey,
                Name = LocMan.GetItemName(item.ConfigKey),
                Description = LocMan.GetDescription(item.ConfigKey, item.LevelNumber),
                Level = item.LevelNumber,
                Costs = GetItemCosts(item),
                Drops = GetItemDrops(item)
            };
        }

        private ItemCostModel GetItemCosts(ItemDefinition item)
        {
            return new ItemCostModel
            {
                Sell = item.SellValue(),
                //SpeedUp = -1, //(int)item.SpawnFeatures.TimeSkipPriceGems(null).Double,
                UnDust = (int)Math.Ceiling(item.UnlockOnBoardPriceGems.Double),
                Bubble = item.BubbleFeatures?.OpenQuantity ?? 0 // CostInDiamonds seems to be the same quantity
            };
        }

        private ItemDropModel GetItemDrops(ItemDefinition item)
        {
            if (item.ChestFeatures?.IsChest ?? false)
            {
                return new ItemDropModel
                {
                    MaxStorage = item.ChestFeatures.HowManyToRoll,
                    Odds = GetOdds(GetChestOdds(item), _dropsAsPercent)
                };
            }

            if (!item.ActivationFeatures?.Activable ?? true)
                return null;

            return new ItemDropModel
            {
                MaxStorage = item.ActivationFeatures.StorageMax,
                CycleAmount = item.ActivationFeatures.ActivationCycle.GetActivationAmountInCycle(),
                Delay = new DurationModel(item.ActivationFeatures.ActivationCycle.GetCycleDelay()),
                Odds = GetOdds(GetActivationOdds(item), _dropsAsPercent)
            };
        }

        private IDictionary<ItemType, double> GetOdds(IEnumerable<(ItemType, int)> odds, bool asPercent)
        {
            // Collect weights
            var res = new Dictionary<ItemType, double>();
            foreach (var odd in odds)
                if (res.ContainsKey(odd.Item1))
                    res[odd.Item1] += odd.Item2;
                else
                    res[odd.Item1] = odd.Item2;

            // Convert to percentages
            if (!asPercent)
                return res;

            var total = res.Values.Sum();
            foreach (var pair in res)
                res[pair.Key] = Math.Round(pair.Value / total * 100, 2);

            return res;
        }

        private IEnumerable<(ItemType, int)> GetChestOdds(ItemDefinition item)
        {
            return item.ChestFeatures.LootProducer?.Odds.Select(x => (x.Item1.ConfigKey, x.Item2)) ?? Array.Empty<(ItemType, int)>();
        }

        private IEnumerable<(ItemType, int)> GetActivationOdds(ItemDefinition item)
        {
            return item.ActivationFeatures.ActivationSpawn.Odds.Select(x => (x.Item1.ConfigKey, x.Item2));
        }
    }
}
