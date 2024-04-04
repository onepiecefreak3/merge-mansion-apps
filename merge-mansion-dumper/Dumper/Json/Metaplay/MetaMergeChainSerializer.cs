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
using GameLogic;
using GameLogic.Player.Items.Activation;
using GameLogic.Player.Items.Persistent;

namespace merge_mansion_dumper.Dumper.Json.Metaplay
{
    class MetaMergeChainSerializer : BaseMetaJsonSerializer
    {
        private readonly ILogger _output;
        private readonly bool _dropAsPercent;
        private readonly Type[] _supportedTypes =
        {
                typeof(MergeChainDefinition),
                typeof(CodexCategoryInfo),
                typeof(ItemDefinition),
                typeof(MergeCollection),
                typeof(IItemProducer),
                typeof(PersistentFeatures)
            };

        public MetaMergeChainSerializer(bool dropAsPercent, ILogger output)
        {
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
                var firstItem = ClientGlobal.SharedGameConfig.Items.GetValueOrDefault(mergePair.Key.First);
                var secondItem = ClientGlobal.SharedGameConfig.Items.GetValueOrDefault(mergePair.Key.Second);

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
                WriteProperty(writer, "ItemType", ClientGlobal.SharedGameConfig.Items.GetValueOrDefault(crp.ItemType).ItemType, serializer);

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
            else
            {
                writer.WriteNull();
                _output.Warning("Unknown producer {0}", producer.GetType().Name);
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

                var sellPrice = item.GetItemSellPrice(ClientGlobal.SharedGameConfig.SharedGlobals);
                WriteProperty(writer, "SellCoins", sellPrice, serializer);
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

            base.WriteObjectMember(writer, name, type, value, serializer);
        }
    }
}
