using GameLogic.Codex;
using GameLogic.Merge;
using GameLogic.MergeChains;
using GameLogic.Player.Items.Production;
using GameLogic.Player.Items;
using Metaplay.Core;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Linq;
using GameLogic.Config;
using GameLogic.Player.Items.Persistent;
using GameLogic.DailyTasksV2;
using GameLogic.Player.Items.Order;
using Metaplay.Core.Math;
using Metaplay.Unity;
using System.Security.Cryptography;
using GameLogic.Player.Items.Sink;
using System.Collections.Generic;

namespace merge_mansion_dumper.Dumper.Json.Metaplay
{
    class MetaMergeChainSerializer : BaseMetaJsonSerializer
    {
        private readonly ILogger _output;
        private readonly bool _dropAsPercent;
        private readonly SharedGameConfig _config;
        private readonly Type[] _supportedTypes =
        {
                typeof(MergeChainDefinition),
                typeof(CodexCategoryInfo),
                typeof(ItemDefinition),
                typeof(MergeCollection),
                typeof(IItemProducer),
                typeof(IOrderProducer),
                typeof(PersistentFeatures),
                typeof(ISinkStateFactory)
            };

        public MetaMergeChainSerializer(SharedGameConfig config, bool dropAsPercent, ILogger output)
        {
            _config = config;
            _dropAsPercent = dropAsPercent;
            _output = output;
        }

        protected override Type[] GetTypes() => _supportedTypes;

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is MergeChainDefinition chainDef)
                SerializeMergeChain(writer, chainDef, serializer);
            if (value is CodexCategoryInfo codex)
                SerializeCodexCategory(writer, codex, serializer);
            else if (value is ItemDefinition item)
                SerializeItem(writer, item, serializer);
            else if (value is MergeCollection mergeCollection)
                SerializeMergeCollection(writer, mergeCollection, serializer);
            else if (value is IItemProducer producer)
                SerializeProducer(writer, producer, serializer);
            else if (value is IOrderProducer orderProducer)
                SerializeOrderProducer(writer, orderProducer, serializer);
            else if (value is ISinkStateFactory sinkFactory)
                WriteObject(writer, sinkFactory.GetType(), sinkFactory, serializer);
            else if (value is PersistentFeatures persistent)
                WriteObject(writer, persistent.GetType(), persistent, serializer);
        }

        private void SerializeMergeChain(JsonWriter writer, MergeChainDefinition chainDef, JsonSerializer serializer)
        {
            if (chainDef.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, chainDef.GetType(), chainDef, serializer);
        }

        private void SerializeCodexCategory(JsonWriter writer, CodexCategoryInfo codex, JsonSerializer serializer)
        {
            if (codex.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, codex.GetType(), codex, serializer);
        }

        private void SerializeItem(JsonWriter writer, ItemDefinition item, JsonSerializer serializer)
        {
            if (item.ConfigKey == 0)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, item.GetType(), item, serializer);
        }

        private void SerializeMergeCollection(JsonWriter writer, MergeCollection mergeCollection, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            foreach (var mergePair in mergeCollection.Collection)
            {
                var firstItem = _config.Items.GetValueOrDefault(mergePair.Key.First);
                var secondItem = _config.Items.GetValueOrDefault(mergePair.Key.Second);

                var pairValue = firstItem.ItemType + ":" + secondItem.ItemType;
                WriteProperty(writer, pairValue, mergePair.Value, serializer);
            }

            writer.WriteEndObject();
        }

        private void SerializeProducer(JsonWriter writer, IItemProducer producer, JsonSerializer serializer)
        {
            if (producer is EmptyProducer)
                WriteValue(writer, "Empty", serializer);
            else if (producer is GarageCleanupEventProducer)
                WriteValue(writer, "GarageCleanupEvent", serializer);
            else if (producer is InstantDecayProducer)
                WriteValue(writer, "InstantDecay", serializer);
            else if (producer is ConstantProducer cp)
            {
                writer.WriteStartObject();

                WriteProperty(writer, "Constant", cp.Products[0].Ref.ItemType, serializer);

                writer.WriteEndObject();
            }
            else if (producer is PrefixProducer pp)
            {
                writer.WriteStartObject();

                WriteProperty(writer, "Marker", pp.Marker, serializer);

                if (pp.BaseProducer != null || serializer.NullValueHandling != NullValueHandling.Ignore)
                {
                    writer.WritePropertyName("BaseProducer");
                    SerializeProducer(writer, pp.BaseProducer, serializer);
                }

                writer.WriteEndObject();
            }
            else if (producer is ControlledRandomProducer crp)
            {
                writer.WriteStartObject();

                writer.WritePropertyName("ControlledRandom");
                writer.WriteStartObject();

                WriteProperty(writer, "RollType", crp.RollType.ToString(), serializer);
                WriteProperty(writer, "ItemType", _config.Items.GetValueOrDefault(crp.ItemType).ItemType, serializer);

                writer.WritePropertyName("Odds");
                writer.WriteStartObject();

                double weightSum = crp.Odds.Sum(x => x.Item2);
                foreach (var odd in crp.Odds.GroupBy(x => x.Item1.ItemType))
                {
                    var weight = _dropAsPercent ?
                        odd.Sum(x => x.Item2) / weightSum * 100 :
                        odd.Sum(x => x.Item2);

                    WriteProperty(writer, odd.Key, weight, serializer);
                }

                writer.WriteEndObject();

                writer.WriteEndObject();

                writer.WriteEndObject();
            }
            else if (producer is RandomProducer rp)
            {
                writer.WriteStartObject();

                writer.WritePropertyName("Random");
                writer.WriteStartObject();

                writer.WritePropertyName("Odds");
                writer.WriteStartObject();

                double weightSum = rp.Odds.Sum(x => x.Item2);
                foreach (var odd in rp.Odds.GroupBy(x => x.Item1.ItemType))
                {
                    var weight = _dropAsPercent ?
                        odd.Sum(x => x.Item2) / weightSum * 100 :
                        odd.Sum(x => x.Item2);

                    WriteProperty(writer, odd.Key, weight, serializer);
                }

                writer.WriteEndObject();

                writer.WriteEndObject();

                writer.WriteEndObject();
            }
            else if (producer is PredefinedSequenceProducer psp)
            {
                writer.WriteStartObject();

                writer.WritePropertyName("PredefinedSequence");
                writer.WriteStartObject();

                writer.WritePropertyName("Odds");
                writer.WriteStartObject();

                double weightSum = psp.Odds.Sum(x => x.Item2);
                foreach (var odd in psp.Odds.GroupBy(x => x.Item1.ItemType))
                {
                    var weight = _dropAsPercent ?
                        odd.Sum(x => x.Item2) / weightSum * 100 :
                        odd.Sum(x => x.Item2);

                    WriteProperty(writer, odd.Key, weight, serializer);
                }

                writer.WriteEndObject();

                writer.WriteEndObject();

                writer.WriteEndObject();
            }
            else if (producer is ControlledRandomSequenceProducer crsp)
            {
                writer.WriteStartObject();

                writer.WritePropertyName("ControlledRandomSequence");
                writer.WriteStartObject();

                writer.WritePropertyName("Odds");
                writer.WriteStartObject();

                double weightSum = crsp.TotalWeight;
                foreach (var odd in crsp.Odds.GroupBy(x => x.Item1.ItemType))
                {
                    var weight = _dropAsPercent ?
                        odd.Sum(x => x.Item2) / weightSum * 100 :
                        odd.Sum(x => x.Item2);

                    WriteProperty(writer, odd.Key, weight, serializer);
                }

                writer.WriteEndObject();

                writer.WriteEndObject();

                writer.WriteEndObject();
            }
            else if (producer is ControlledMixedSequenceProducer cmsp)
            {
                writer.WriteStartObject();

                writer.WritePropertyName("ControlledMixedSequence");
                writer.WriteStartObject();

                WriteProperty(writer, "RollType", cmsp.RollType.ToString(), serializer);
                WriteProperty(writer, "ItemType", _config.Items.GetValueOrDefault(cmsp.ItemType).ItemType, serializer);

                writer.WritePropertyName("Odds");
                writer.WriteStartObject();

                double weightSum = cmsp.Odds.Sum(x => x.Item2);
                foreach (var odd in cmsp.Odds.GroupBy(x => x.Item1.ItemType))
                {
                    var weight = _dropAsPercent ?
                        odd.Sum(x => x.Item2) / weightSum * 100 :
                        odd.Sum(x => x.Item2);

                    WriteProperty(writer, odd.Key, weight, serializer);
                }

                writer.WriteEndObject();

                writer.WriteEndObject();

                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNull();
                _output.Warning("Unknown producer {0}", producer.GetType().Name);
            }
        }

        private void SerializeOrderProducer(JsonWriter writer, IOrderProducer producer, JsonSerializer serializer)
        {
            if (producer is ConstantOrderProducer cop)
            {
                writer.WriteStartObject();

                writer.WritePropertyName("Constant");
                writer.WriteStartObject();

                WriteProperty(writer, "RollType", cop.RollType.ToString(), serializer);
                WriteProperty(writer, "ItemType", _config.Items.GetValueOrDefault(cop.ItemType).ItemType, serializer);

                writer.WritePropertyName("Tasks");
                writer.WriteStartArray();

                double weightSum = cop.GenerationOdds.Sum(x => x.Item2);
                foreach ((OrderRequirementsId, int) odds in cop.GenerationOdds)
                {
                    if (!_config.OrderRequirements.TryGetValue(odds.Item1, out var orderRequirements))
                        continue;

                    writer.WriteStartObject();

                    var weight = _dropAsPercent ?
                        odds.Item2 / weightSum * 100 :
                        odds.Item2;
                    WriteProperty(writer, "Odds", weight, serializer);

                    writer.WritePropertyName("Required");
                    writer.WriteStartArray();

                    foreach (var item in orderRequirements.SinkItemsAndAmounts)
                    {
                        writer.WriteStartObject();

                        if (!_config.Items.TryGetValue(item.Key, out var itemDefinition))
                            continue;

                        WriteProperty(writer, "Item", itemDefinition.ItemType, serializer);
                        WriteProperty(writer, "Amount", item.Value, serializer);

                        writer.WriteEndObject();
                    }

                    writer.WriteEndArray();

                    writer.WritePropertyName("Rewards");
                    writer.WriteStartArray();

                    foreach (var item in orderRequirements.ActivationRewardsAndAmounts)
                    {
                        writer.WriteStartObject();

                        if (!_config.Items.TryGetValue(item.Key, out var itemDefinition))
                            continue;

                        WriteProperty(writer, "Item", itemDefinition.ItemType, serializer);
                        WriteProperty(writer, "Amount", item.Value, serializer);

                        writer.WriteEndObject();
                    }

                    writer.WriteEndArray();

                    writer.WriteEndObject();
                }

                writer.WriteEndArray();

                writer.WriteEndObject();

                writer.WriteEndObject();
            }
            else if (producer is ControlledRandomOrderProducer crod)
                ;
            else
            {
                writer.WriteNull();
                _output.Warning("Unknown order producer {0}", producer.GetType().Name);
            }
        }

        protected override void WriteCustomObjectMembers(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is MergeChainDefinition mergeChain)
            {
                if (LocMan.HasString(LocMan.GetItemCategoryNameLocId(mergeChain.ConfigKey)))
                    WriteProperty(writer, "Name", LocMan.GetItemCategoryName(mergeChain.ConfigKey), serializer);
            }
            else if (value is ItemDefinition item)
            {
                var itemName = LocMan.GetItemName(item.ItemType);
                if (itemName != null)
                    WriteProperty(writer, "Name", itemName, serializer);

                var descName = LocMan.GetDescription(item.ItemType, item.LevelNumber);
                if (descName != null)
                    WriteProperty(writer, "Description", descName, serializer);

                var sellPrice = item.GetItemSellPrice(_config.SharedGlobals);
                WriteProperty(writer, "SellCoins", sellPrice, serializer);

                if (item.BubbleFeatures != null)
                {
                    var dailyTaskChain = (DailyTasksV2MergeChainInfo)_config.DailyTasksV2MergeChains.GetInfoByKey(item.MergeChainRef.KeyObject);

                    F32 requiredMultiplier = dailyTaskChain?.RequirementMultiplier ?? new F32(0x10000);
                    int requiredItemValue = F32.RoundToInt(requiredMultiplier * item.BubbleFeatures.OpenCost.Item2);

                    F32 rewardedMultiplier = dailyTaskChain?.RewardMultiplier ?? new F32(0x10000);
                    int rewardedItemValue = F32.RoundToInt(rewardedMultiplier * item.BubbleFeatures.OpenCost.Item2);

                    WriteProperty(writer, "RequiredItemValue", requiredItemValue, serializer);
                    WriteProperty(writer, "RewardItemValue", rewardedItemValue, serializer);
                }
            }
        }

        protected override void WriteObjectMember(JsonWriter writer, string name, Type type, object value, JsonSerializer serializer)
        {
            if (type.IsAssignableTo(typeof(CodexCategoryInfo)))
            {
                if (name == nameof(CodexCategoryInfo.IconItem))
                {
                    WriteProperty(writer, name, (value as MetaRef<ItemDefinition>)?.Ref.ItemType ?? string.Empty, serializer);
                    return;
                }
            }
            else if (type.IsAssignableTo(typeof(ItemDefinition)))
            {
                if (name == nameof(ItemDefinition.MergeChainRef))
                {
                    WriteProperty(writer, name, (value as IMetaRef)?.KeyObject, serializer);
                    return;
                }
            }
            else if (type.IsAssignableTo(typeof(PersistentFeatures)))
            {
                if (name == nameof(PersistentFeatures.ResetToItem))
                {
                    WriteProperty(writer, name, (value as MetaRef<ItemDefinition>)?.Ref.ItemType ?? string.Empty, serializer);
                    return;
                }
            }
            else if (type.IsAssignableTo(typeof(MultiTargetSinkStateFactory)))
            {
                if (name == nameof(MultiTargetSinkStateFactory.Reward))
                {
                    WriteProperty(writer, name, (value as MetaRef<ItemDefinition>)?.Ref.ItemType ?? string.Empty, serializer);
                    return;
                }
            }

            base.WriteObjectMember(writer, name, type, value, serializer);
        }
    }
}
