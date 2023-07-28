using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using merge_mansion_dumper.Graphs;
using Metaplay;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.GameLogic.Area;
using Metaplay.GameLogic.Codex;
using Metaplay.GameLogic.Config;
using Metaplay.GameLogic.Config.Costs;
using Metaplay.GameLogic.Hotspots;
using Metaplay.GameLogic.MergeChains;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.GameLogic.Player.Items;
using Metaplay.GameLogic.Player.Items.Production;
using Metaplay.GameLogic.Player.Requirements;
using Metaplay.GameLogic.Player.Rewards;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Schedule;
using MoreLinq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace merge_mansion_dumper.Dumper.Json
{
    class MergeMansionJsonConverter : JsonConverter
    {
        abstract class BaseMetaJsonSerializer : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                var types = GetTypes();
                return types.Contains(objectType) || types.Any(objectType.IsAssignableTo);
            }

            protected abstract Type[] GetTypes();

            public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            protected void SerializeMetaRef(JsonWriter writer, IMetaRef metaRef, JsonSerializer serializer)
            {
                if (!metaRef.IsResolved)
                {
                    serializer.Serialize(writer, metaRef.KeyObject);
                    return;
                }

                serializer.Serialize(writer, metaRef.GetType().GetProperty("Ref")?.GetValue(metaRef));
            }
        }

        class MetaJsonSerializer : BaseMetaJsonSerializer
        {
            private readonly ILogger _output;
            private readonly Type[] _supportedTypes =
            {
                typeof(MetaDuration),
                typeof(MetaTime),
                typeof(MetaCalendarDateTime),
                typeof(MetaCalendarPeriod),
                typeof(ContentHash),
                typeof(PlayerRequirement),
                typeof(PlayerReward),
                typeof(IDirectorAction),
                typeof(IStringId),
                typeof(IMetaRef)
            };

            public MetaJsonSerializer(ILogger output)
            {
                _output = output;
            }

            protected override Type[] GetTypes() => _supportedTypes;

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is MetaDuration dur)
                    new JValue(dur.Milliseconds).WriteTo(writer);
                else if (value is MetaTime time)
                    new JValue(time.ToDateTime()).WriteTo(writer);
                else if (value is MetaCalendarDateTime calTime)
                    new JValue(calTime.ToDateTime()).WriteTo(writer);
                else if (value is MetaCalendarPeriod period)
                    SerializePeriod(writer, period, serializer);
                else if (value is ContentHash hash)
                    new JValue(hash.ToString()).WriteTo(writer);
                else if (value is PlayerRequirement pr)
                    SerializePlayerRequirement(writer, pr, serializer);
                else if (value is PlayerReward prew)
                    SerializePlayerReward(writer, prew, serializer);
                else if (value is IDirectorAction dirAct)
                    SerializeDirectorAction(writer, dirAct, serializer);
                else if (value is IStringId sId)
                    new JValue(sId.Value).WriteTo(writer);
                else if (value is IMetaRef metaRef)
                    SerializeMetaRef(writer, metaRef, serializer);
            }

            private void SerializePeriod(JsonWriter writer, MetaCalendarPeriod period, JsonSerializer serializer)
            {
                var parts = new List<string>();
                var trailingZeroes = false;

                if (period.Years > 0)
                {
                    parts.Add($"{period.Years}y");
                    trailingZeroes = true;
                }
                if (period.Months > 0 || trailingZeroes)
                {
                    parts.Add($"{period.Months}mo");
                    trailingZeroes = true;
                }
                if (period.Days > 0 || trailingZeroes)
                {
                    parts.Add($"{period.Days}d");
                    trailingZeroes = true;
                }
                if (period.Hours > 0 || trailingZeroes)
                {
                    parts.Add($"{period.Hours}h");
                    trailingZeroes = true;
                }
                if (period.Minutes > 0 || trailingZeroes)
                {
                    parts.Add($"{period.Minutes}min");
                    trailingZeroes = true;
                }
                if (period.Seconds > 0 || trailingZeroes)
                    parts.Add($"{period.Seconds}s");

                new JValue(string.Join(" ", parts)).WriteTo(writer);
            }

            private void SerializePlayerRequirement(JsonWriter writer, PlayerRequirement requirement, JsonSerializer serializer)
            {
                if (requirement is ImpossibleRequirement)
                {
                    JValue.CreateString("Impossible").WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                if (requirement is AreaCompletedRequirement aReq)
                {
                    writer.WritePropertyName("AreaCompleted");
                    serializer.Serialize(writer, aReq.AreaRef.KeyObject);
                }
                else if (requirement is HotspotCompletedRequirement hReq)
                {
                    writer.WritePropertyName("HotspotCompleted");
                    serializer.Serialize(writer, hReq.hotspot.KeyObject);
                }
                else if (requirement is HotspotVisibleOrCompletedRequirement hvcReq)
                {
                    writer.WritePropertyName("HotspotVisibleOrCompleted");
                    serializer.Serialize(writer, hvcReq.hotspot.KeyObject);
                }
                else if (requirement is CostRequirement cReq)
                {
                    writer.WritePropertyName("RequiredCost");
                    serializer.Serialize(writer, cReq.RequiredCost);
                }
                else if (requirement is HotspotVisibleRequirement hvReq)
                {
                    writer.WritePropertyName("HotspotVisible");
                    serializer.Serialize(writer, hvReq.hotspot.KeyObject);
                }
                else if (requirement is ItemNeededRequirement inReq)
                {
                    writer.WritePropertyName("ItemNeeded");
                    serializer.Serialize(writer, inReq.ItemRef.KeyObject);
                }
                else if (requirement is MergeChainItemNeededRequirement mciReq)
                {
                    writer.WritePropertyName("MergeChainItemNeeded");
                    writer.WriteStartObject();

                    writer.WritePropertyName("MergeChainRef");
                    serializer.Serialize(writer, mciReq.MergeChainRef.KeyObject);

                    if (mciReq.MinLevel.HasValue)
                    {
                        writer.WritePropertyName("MinLevel");
                        serializer.Serialize(writer, mciReq.MinLevel);
                    }

                    if (mciReq.MaxLevel.HasValue)
                    {
                        writer.WritePropertyName("MaxLevel");
                        serializer.Serialize(writer, mciReq.MinLevel);
                    }

                    writer.WriteEndObject();
                }
                else if (requirement is PlayerItemRequirement piReq)
                {
                    writer.WritePropertyName("ItemAcquired");
                    writer.WriteStartObject();

                    writer.WritePropertyName("ItemRef");
                    serializer.Serialize(writer, piReq.Item.ConfigKey);

                    writer.WritePropertyName("Requirement");
                    serializer.Serialize(writer, piReq.Requirement);

                    writer.WriteEndObject();
                }
                else if (requirement is PlayerSeenItemRequirement psiReq)
                {
                    writer.WritePropertyName("ItemSeen");
                    writer.WriteStartObject();

                    writer.WritePropertyName("ItemRef");
                    serializer.Serialize(writer, psiReq.ItemRef.KeyObject);

                    writer.WritePropertyName("Requirement");
                    serializer.Serialize(writer, psiReq.Requirement);

                    writer.WriteEndObject();
                }
                else if (requirement is PlayerLevelRequirement plReq)
                {
                    writer.WritePropertyName("LevelNeeded");
                    writer.WriteStartObject();

                    if (plReq.Min.HasValue)
                    {
                        writer.WritePropertyName("Min");
                        serializer.Serialize(writer, plReq.Min);
                    }

                    if (plReq.Max.HasValue)
                    {
                        writer.WritePropertyName("Max");
                        serializer.Serialize(writer, plReq.Max);
                    }

                    writer.WriteEndObject();
                }
                else if (requirement is PlayerCurrentTimeRequirement pctReq)
                {
                    writer.WritePropertyName("TimeNeeded");
                    writer.WriteStartObject();

                    if (pctReq.StartInclusive.HasValue)
                    {
                        writer.WritePropertyName("StartInclusive");
                        serializer.Serialize(writer, pctReq.StartInclusive);
                    }

                    if (pctReq.EndExclusive.HasValue)
                    {
                        writer.WritePropertyName("EndExclusive");
                        serializer.Serialize(writer, pctReq.EndExclusive);
                    }

                    writer.WriteEndObject();
                }
                else if (requirement is ItemNeededAndConsumeRequirement inacReq)
                {
                    writer.WritePropertyName("ItemNeededAndConsumed");
                    serializer.Serialize(writer, inacReq.ItemRefs.FirstOrDefault()?.KeyObject);
                }
                else
                    _output.Warning("Unknown requirement {0}", requirement.GetType().Name);

                writer.WriteEndObject();
            }

            private void SerializePlayerReward(JsonWriter writer, PlayerReward rewardItem, JsonSerializer serializer)
            {
                writer.WriteStartObject();

                writer.WritePropertyName(rewardItem.GetType().Name);
                writer.WriteStartObject();

                foreach (var prop in rewardItem.GetType().GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(rewardItem);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (prop.Name == "ItemRef")
                    {
                        writer.WritePropertyName(prop.Name);
                        serializer.Serialize(writer, (value as IMetaRef)?.KeyObject);

                        continue;
                    }

                    if (value is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();

                writer.WriteEndObject();
            }

            private void SerializeDirectorAction(JsonWriter writer, IDirectorAction directorAction, JsonSerializer serializer)
            {
                writer.WriteStartObject();

                writer.WritePropertyName(directorAction.GetType().Name);
                writer.WriteStartObject();

                foreach (var prop in directorAction.GetType().GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(directorAction);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (value is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();

                writer.WriteEndObject();
            }
        }

        class MetaMathJsonSerializer : BaseMetaJsonSerializer
        {
            private readonly Type[] _supportedTypes =
            {
                typeof(F32),
                typeof(F64),
                typeof(UInt128)
            };

            protected override Type[] GetTypes() => _supportedTypes;

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is F32 f32)
                    new JValue(Math.Ceiling(f32.Double)).WriteTo(writer);
                else if (value is F64 f64)
                    new JValue(Math.Ceiling(f64.Double)).WriteTo(writer);
                else if (value is UInt128 uint128)
                    new JValue(uint128.ToString()).WriteTo(writer);
            }
        }

        class MetaMergeChainSerializer : BaseMetaJsonSerializer
        {
            private readonly ILogger _output;
            private readonly bool _dropAsPercent;
            private readonly Type[] _supportedTypes =
            {
                typeof(MergeChainDefinition),
                typeof(CodexCategoryInfo),
                typeof(ItemDefinition),
                typeof(IItemSpawner)
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
                else if (value is IItemSpawner spawner)
                    SerializeProducer(writer, spawner, serializer);
            }

            private void SerializeMergeChain(JsonWriter writer, MergeChainDefinition chainDef, JsonSerializer serializer)
            {
                if (chainDef.ConfigKey.Value == null)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                var chainName = LocMan.GetItemCategoryName(chainDef.ConfigKey);
                if (chainName != null)
                    new JProperty("Name", chainName).WriteTo(writer);

                foreach (var prop in typeof(MergeChainDefinition).GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(chainDef);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (value is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();
            }

            private void SerializeCodexCategory(JsonWriter writer, CodexCategoryInfo codex, JsonSerializer serializer)
            {
                if (codex.ConfigKey.Value == null)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                foreach (var prop in typeof(CodexCategoryInfo).GetProperties((BindingFlags)52))
                {
                    var propValue = prop.GetValue(codex);

                    if (prop.Name == "IconItem")
                    {
                        writer.WritePropertyName(prop.Name);
                        serializer.Serialize(writer, (propValue as IMetaRef)?.KeyObject);

                        continue;
                    }

                    if (propValue == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (propValue is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, propValue);
                }

                writer.WriteEndObject();
            }

            private void SerializeItem(JsonWriter writer, ItemDefinition item, JsonSerializer serializer)
            {
                if (!Enum.IsDefined(item.ConfigKey))
                    _output.Warning(Program.VersionBumped ? "ItemType {0} unknown" : "[Metacore] ItemType {0} unknown", item.ConfigKey);

                if (item.ConfigKey == ItemTypeConstant.None)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                var itemName = LocMan.GetItemName(item.ConfigKey);
                if (itemName != null)
                    new JProperty("Name", itemName).WriteTo(writer);

                var descName = LocMan.GetDescription(item.ConfigKey, item.LevelNumber);
                if (descName != null)
                    new JProperty("Description", descName).WriteTo(writer);

                new JProperty("SellCoins", item.SellValue()).WriteTo(writer);

                foreach (var prop in typeof(ItemDefinition).GetProperties((BindingFlags)52))
                {
                    var propValue = prop.GetValue(item);

                    if (prop.Name == "MergeChainRef")
                    {
                        writer.WritePropertyName(prop.Name);
                        serializer.Serialize(writer, (propValue as IMetaRef)?.KeyObject);

                        continue;
                    }

                    if (propValue == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (propValue is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, propValue);
                }

                writer.WriteEndObject();
            }

            private void SerializeProducer(JsonWriter writer, IItemSpawner spawner, JsonSerializer serializer)
            {
                if (spawner is EmptyProducer)
                    new JValue("Empty").WriteTo(writer);
                else if (spawner is GarageCleanupEventProducer)
                    new JValue("GarageCleanupEvent").WriteTo(writer);

                else if (spawner is ConstantProducer cp)
                {
                    writer.WriteStartObject();

                    new JProperty("Constant", cp.Products[0].KeyObject.ToString()).WriteTo(writer);

                    writer.WriteEndObject();
                }

                else if (spawner is PrefixProducer pp)
                {
                    writer.WriteStartObject();

                    new JProperty("Marker", pp.Marker).WriteTo(writer);

                    if (pp.BaseProducer != null || serializer.NullValueHandling != NullValueHandling.Ignore)
                    {
                        writer.WritePropertyName("BaseProducer");
                        SerializeProducer(writer, pp.BaseProducer, serializer);
                    }

                    writer.WriteEndObject();
                }

                else if (spawner is ControlledRandomProducer crp)
                {
                    writer.WriteStartObject();

                    writer.WritePropertyName("ControlledRandom");
                    writer.WriteStartObject();

                    new JProperty("RollType", crp.RollType.ToString()).WriteTo(writer);
                    new JProperty("ItemType", crp.ItemType.ToString()).WriteTo(writer);

                    writer.WritePropertyName("Odds");
                    writer.WriteStartObject();

                    double weightSum = crp.GenerationOdds.Sum(x => x.Weight);
                    foreach (var odd in crp.GenerationOdds.GroupBy(x => x.Type.KeyObject.ToString()))
                    {
                        writer.WritePropertyName(odd.Key);
                        serializer.Serialize(writer, _dropAsPercent ? odd.Sum(x => x.Weight) / weightSum * 100 : odd.Sum(x => x.Weight));
                    }

                    writer.WriteEndObject();

                    writer.WriteEndObject();

                    writer.WriteEndObject();
                }
                else if (spawner is RandomProducer rp)
                {
                    writer.WriteStartObject();

                    writer.WritePropertyName("Random");
                    writer.WriteStartObject();

                    writer.WritePropertyName("Odds");
                    writer.WriteStartObject();

                    double weightSum = rp.OddsList.Sum(x => x.Weight);
                    foreach (var odd in rp.OddsList.GroupBy(x => x.Type.KeyObject.ToString()))
                    {
                        writer.WritePropertyName(odd.Key);
                        serializer.Serialize(writer, _dropAsPercent ? odd.Sum(x => x.Weight) / weightSum * 100 : odd.Sum(x => x.Weight));
                    }

                    writer.WriteEndObject();

                    writer.WriteEndObject();

                    writer.WriteEndObject();
                }
            }
        }

        class MetaAreaSerializer : BaseMetaJsonSerializer
        {
            private readonly SharedGameConfig _config;
            private readonly ILogger _output;
            private readonly Type[] _supportedTypes =
            {
                typeof(AreaInfo),
                typeof(HotspotDefinition)
            };

            public MetaAreaSerializer(SharedGameConfig config, ILogger output)
            {
                _config = config;
                _output = output;
            }

            protected override Type[] GetTypes() => _supportedTypes;

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is AreaInfo area)
                    SerializeArea(writer, area, serializer);
                else if (value is HotspotDefinition hotspot)
                    SerializeHotspot(writer, hotspot, serializer);
            }

            private void SerializeArea(JsonWriter writer, AreaInfo area, JsonSerializer serializer)
            {
                if (area.ConfigKey.Value == null)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                var areaName = LocMan.GetHotspotTitle(area.AreaId);
                if (areaName != null)
                    new JProperty("Name", areaName).WriteTo(writer);

                var hotspots = area.HotspotsRefs.DistinctBy(x => x.Ref.ConfigKey).ToArray();
                if (area.HotspotsRefs.Count != hotspots.Length)
                    _output.Warning("[Metacore] Area {0} has {1} duplicated tasks.", area.ConfigKey, area.HotspotsRefs.Count - hotspots.Length);

                new JProperty("TaskDependencies", GetTaskGraph(hotspots)).WriteTo(writer);

                foreach (var prop in typeof(AreaInfo).GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(area);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (prop.Name == nameof(AreaInfo.UnlockingHotspotRef))
                    {
                        writer.WritePropertyName(prop.Name);
                        serializer.Serialize(writer, (value as IMetaRef)?.KeyObject);

                        continue;
                    }

                    if (prop.Name == nameof(AreaInfo.HotspotsRefs))
                    {
                        writer.WritePropertyName(prop.Name);
                        serializer.Serialize(writer, hotspots);

                        continue;
                    }

                    if (value is IMetaRef { IsResolved: false })
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();
            }

            private void SerializeHotspot(JsonWriter writer, HotspotDefinition hotspot, JsonSerializer serializer)
            {
                if (!Enum.IsDefined(hotspot.ConfigKey))
                    _output.Warning(Program.VersionBumped ? "HotspotId {0} unknown" : "[Metacore] HotspotId {0} unknown", hotspot.ConfigKey);

                if (hotspot.ConfigKey == HotspotId.None)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                var hotspotDesc = LocMan.GetHotspotDescription(hotspot.Id);
                if (hotspotDesc != null)
                    new JProperty("Description", hotspotDesc).WriteTo(writer);

                foreach (var prop in typeof(HotspotDefinition).GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(hotspot);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (prop.Name == "AreaRef")
                    {
                        writer.WritePropertyName(prop.Name);
                        serializer.Serialize(writer, (value as IMetaRef)?.KeyObject);

                        continue;
                    }
                    if (prop.Name == "UnlockingParentRefs")
                    {
                        writer.WritePropertyName(prop.Name);
                        writer.WriteStartArray();

                        foreach (var task in (List<MetaRef<HotspotDefinition>>)value)
                            serializer.Serialize(writer, task.KeyObject);

                        writer.WriteEndArray();

                        continue;
                    }

                    if (value is IMetaRef { IsResolved: false })
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();
            }

            #region Task graphs

            private string GetTaskGraph(IList<MetaRef<HotspotDefinition>> hotspots)
            {
                var nodes = GetTaskNodes(hotspots);
                return GraphViz.GetGraph(nodes);
            }

            private IList<Node> GetTaskNodes(IList<MetaRef<HotspotDefinition>> hotspots)
            {
                var hotspotDict = new Dictionary<HotspotId, Node>();
                foreach (var hotspot in hotspots.Where(x => x.Ref.ConfigKey != HotspotId.None).OrderBy(x => x.Ref.ConfigKey))
                {
                    if (!hotspotDict.TryGetValue(hotspot.Ref.ConfigKey, out var node))
                        node = new Node { Text = GetNodeText(hotspot.Ref) };

                    foreach (var unlockParent in hotspot.Ref.UnlockingParentRefs)
                    {
                        if (!hotspotDict.TryGetValue(unlockParent.Ref.Id, out var unlockParentNode))
                            hotspotDict[unlockParent.Ref.Id] = unlockParentNode = new Node { Text = GetNodeText((HotspotDefinition)_config.HotspotDefinitions.EnumerateAll().FirstOrDefault(x => (HotspotId)x.Key == unlockParent.Ref.Id).Value) };

                        unlockParentNode.AddChild(node);
                    }

                    hotspotDict[hotspot.Ref.ConfigKey] = node;
                }

                return hotspotDict.Values.ToArray();
            }


            private string GetNodeText(HotspotDefinition hotspot)
            {
                if (hotspot == null)
                    return null;

                var res = hotspot.ConfigKey + Environment.NewLine + LocMan.GetHotspotDescription(hotspot.ConfigKey);

                foreach (var req in hotspot.RequirementsList)
                {
                    if (req is PlayerItemRequirement pir)
                        res += Environment.NewLine + LocMan.GetItemName(pir.Item.ConfigKey) + " x" + pir.Requirement;
                    else if (req is CostRequirement cr && cr.RequiredCost is CurrencyCost cc)
                        res += Environment.NewLine + "Coins x" + cc.CurrencyAmount;
                }

                return res;
            }

            #endregion
        }

        class MetaEventSerializer : BaseMetaJsonSerializer
        {
            private readonly Type[] _supportedTypes =
            {
                typeof(BoardEventInfo),
                typeof(ProgressionEventInfo),
                typeof(CollectibleBoardEventInfo),
                typeof(LeaderboardEventInfo),
                typeof(EventTaskInfo),
                typeof(ShopEventInfo)
            };

            protected override Type[] GetTypes() => _supportedTypes;

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is BoardEventInfo bei)
                    SerializeBoardEvent(writer, bei, serializer);
                else if (value is ProgressionEventInfo pei)
                    SerializeProgressionEvent(writer, pei, serializer);
                else if (value is CollectibleBoardEventInfo cbei)
                    SerializeCollectibleBoardEvent(writer, cbei, serializer);
                else if (value is LeaderboardEventInfo lei)
                    SerializeLeaderboardEvent(writer, lei, serializer);
                else if (value is EventTaskInfo eti)
                    SerializeEventTask(writer, eti, serializer);
                else if (value is ShopEventInfo sei)
                    SerializeShopEvent(writer, sei, serializer);
            }

            private void SerializeBoardEvent(JsonWriter writer, BoardEventInfo boardEvent, JsonSerializer serializer)
            {
                if (boardEvent.ConfigKey.Value == null)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                writer.WritePropertyName("TaskDependencies");
                serializer.Serialize(writer, GetTaskGraph(boardEvent));

                // TODO: Include story definitions
                //var story = (StoryElementInfo)config.StoryElements.GetInfoByKey(eventInfo.StartEventDialogue);
                //if (story == null)
                //    return model;

                //foreach (var dialogItem in story.DialogItems)
                //{
                //    model.Story ??= new List<DialogModel>();

                //    model.Story.Add(new DialogModel
                //    {
                //        Speaker = dialogItem.Value.Ref.RightSpeaks ? dialogItem.Value.Ref.RightCharacter.ToString() : dialogItem.Value.Ref.LeftCharacter.ToString(),
                //        Mood = dialogItem.Value.Ref.RightSpeaks ? dialogItem.Value.Ref.RightCharacterState.ToString() : dialogItem.Value.Ref.LeftCharacterState.ToString(),
                //        Text = LocMan.Get(dialogItem.Value.Ref.LocalizationId)
                //    });
                //}

                foreach (var prop in typeof(BoardEventInfo).GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(boardEvent);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (prop.Name == "EventInitTask")
                    {
                        writer.WritePropertyName(prop.Name);
                        serializer.Serialize(writer, (value as IMetaRef)?.KeyObject);

                        continue;
                    }

                    if (value is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();
            }

            private void SerializeProgressionEvent(JsonWriter writer, ProgressionEventInfo progressionEvent, JsonSerializer serializer)
            {
                if (progressionEvent.ConfigKey.Value == null)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                // TODO: Include story definitions
                //var story = (StoryElementInfo)config.StoryElements.GetInfoByKey(eventInfo.StartEventDialogue);
                //if (story == null)
                //    return model;

                //foreach (var dialogItem in story.DialogItems)
                //{
                //    model.Story ??= new List<DialogModel>();

                //    model.Story.Add(new DialogModel
                //    {
                //        Speaker = dialogItem.Value.Ref.RightSpeaks ? dialogItem.Value.Ref.RightCharacter.ToString() : dialogItem.Value.Ref.LeftCharacter.ToString(),
                //        Mood = dialogItem.Value.Ref.RightSpeaks ? dialogItem.Value.Ref.RightCharacterState.ToString() : dialogItem.Value.Ref.LeftCharacterState.ToString(),
                //        Text = LocMan.Get(dialogItem.Value.Ref.LocalizationId)
                //    });
                //}

                foreach (var prop in typeof(ProgressionEventInfo).GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(progressionEvent);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (value is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();
            }

            private void SerializeCollectibleBoardEvent(JsonWriter writer, CollectibleBoardEventInfo collectibleEvent, JsonSerializer serializer)
            {
                if (collectibleEvent.ConfigKey.Value == null)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                foreach (var prop in typeof(CollectibleBoardEventInfo).GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(collectibleEvent);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (value is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();
            }

            private void SerializeLeaderboardEvent(JsonWriter writer, LeaderboardEventInfo leaderBoardEvent, JsonSerializer serializer)
            {
                if (leaderBoardEvent.ConfigKey.Value == null)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                foreach (var prop in typeof(LeaderboardEventInfo).GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(leaderBoardEvent);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (value is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();
            }

            private void SerializeShopEvent(JsonWriter writer, ShopEventInfo shopEvent, JsonSerializer serializer)
            {
                if (shopEvent.ConfigKey.Value == null)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                foreach (var prop in typeof(ShopEventInfo).GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(shopEvent);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (prop.Name == "HintedBoardEventInfos")
                    {
                        writer.WritePropertyName(prop.Name);
                        writer.WriteStartArray();

                        foreach (var task in (List<MetaRef<BoardEventInfo>>)value)
                            serializer.Serialize(writer, task.KeyObject);

                        writer.WriteEndArray();

                        continue;
                    }

                    if (value is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();
            }

            private void SerializeEventTask(JsonWriter writer, EventTaskInfo eventTask, JsonSerializer serializer)
            {
                if (eventTask.ConfigKey.Value == null)
                {
                    new JObject().WriteTo(writer);
                    return;
                }

                writer.WriteStartObject();

                foreach (var prop in typeof(EventTaskInfo).GetProperties((BindingFlags)52))
                {
                    var value = prop.GetValue(eventTask);
                    if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;

                    if (prop.Name == "UnlockTaskRefs")
                    {
                        writer.WritePropertyName(prop.Name);
                        writer.WriteStartArray();

                        foreach (var task in (List<MetaRef<EventTaskInfo>>)value)
                            serializer.Serialize(writer, task.KeyObject);

                        writer.WriteEndArray();

                        continue;
                    }

                    if (value is IMetaRef mRef && !mRef.IsResolved)
                        continue;

                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, value);
                }

                writer.WriteEndObject();
            }

            #region Task graph

            private string GetTaskGraph(BoardEventInfo area)
            {
                var nodes = GetTaskNodes(area);
                return GraphViz.GetGraph(nodes);
            }

            private IList<Node> GetTaskNodes(BoardEventInfo eventInfo)
            {
                if (eventInfo.EventTasks.Count <= 0)
                    return Array.Empty<Node>();

                var root = eventInfo.EventInitTask.Ref;

                var nodeDict = new Dictionary<EventTaskId, Node> { [root.ConfigKey] = new Node { Text = GetNodeText(root) } };
                foreach (var task in eventInfo.EventTasks)
                {
                    if (!nodeDict.TryGetValue(task.Ref.ConfigKey, out var node))
                        node = new Node { Text = GetNodeText(task.Ref) };

                    if (task.Ref.UnlockTaskRefs != null)
                        foreach (var unlockTask in task.Ref.UnlockTaskRefs)
                        {
                            if (!nodeDict.TryGetValue(unlockTask.Ref.ConfigKey, out var unlockNode))
                                nodeDict[unlockTask.Ref.ConfigKey] = unlockNode = new Node { Text = GetNodeText(unlockTask.Ref) };

                            node.AddChild(unlockNode);
                        }

                    nodeDict[task.Ref.ConfigKey] = node;
                }

                return nodeDict.Values.ToArray();
            }

            private string GetNodeText(EventTaskInfo taskInfo)
            {
                if (taskInfo == null)
                    return null;

                var res = LocMan.Get(taskInfo.Description)?.Replace("\"", "'") ?? string.Empty;

                foreach (var req in taskInfo.Requirements)
                {
                    if (req is PlayerItemRequirement pir)
                        res += Environment.NewLine + LocMan.GetItemName(pir.Item.ConfigKey) + " x" + pir.Requirement;
                }

                return res;
            }

            #endregion
        }

        private readonly BaseMetaJsonSerializer[] _serializers;

        public MergeMansionJsonConverter(SharedGameConfig resolver, ILogger output, bool dropsAsPercent)
        {
            _serializers = new BaseMetaJsonSerializer[]
            {
                new MetaJsonSerializer(output),
                new MetaMathJsonSerializer(),
                new MetaMergeChainSerializer(dropsAsPercent, output),
                new MetaAreaSerializer(resolver, output),
                new MetaEventSerializer(),
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return _serializers.Any(s => s.CanConvert(objectType));
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                JValue.CreateNull().WriteTo(writer);
                return;
            }

            foreach (var s in _serializers)
            {
                if (!s.CanConvert(value.GetType()))
                    continue;

                s.WriteJson(writer, value, serializer);
            }
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
