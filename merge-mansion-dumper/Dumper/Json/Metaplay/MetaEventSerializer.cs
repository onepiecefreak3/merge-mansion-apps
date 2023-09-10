using Code.GameLogic.GameEvents;
using merge_mansion_dumper.Graphs;
using Metaplay.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using GameLogic;
using GameLogic.Player.Items;
using System.Threading.Tasks;

namespace merge_mansion_dumper.Dumper.Json.Metaplay
{
    class MetaEventSerializer : BaseMetaJsonSerializer
    {
        private readonly Type[] _supportedTypes =
        {
                typeof(BoardEventInfo),
                typeof(ProgressionEventInfo),
                typeof(CollectibleBoardEventInfo),
                typeof(LeaderboardEventInfo),
                typeof(EventTaskInfo),
                typeof(ShopEventInfo),

                typeof(GarageCleanupEventInfo),
                typeof(GarageCleanupRewardInfo),
                typeof(GarageCleanupBoardInfo),
                typeof(GarageCleanupBoardRowInfo),
                typeof(GarageCleanupPatternInfo),

                typeof(BoardCell),
                typeof(EventOfferSetInfo)
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

            else if (value is GarageCleanupEventInfo gcei)
                SerializeGarageCleanupEvent(writer, gcei, serializer);
            else if (value is GarageCleanupRewardInfo rewardInfo)
                SerializeGarageCleanupRewardInfo(writer, rewardInfo, serializer);
            else if (value is GarageCleanupBoardInfo boardInfo)
                SerializeGarageCleanupBoardInfo(writer, boardInfo, serializer);
            else if (value is GarageCleanupBoardRowInfo rowInfo)
                SerializeGarageCleanupBoardRowInfo(writer, rowInfo, serializer);
            else if (value is GarageCleanupPatternInfo patternInfo)
                SerializeGarageCleanupPatternInfo(writer, patternInfo, serializer);

            else if (value is BoardCell boardCell)
                SerializeBoardCell(writer, boardCell, serializer);
            else if (value is EventOfferSetInfo eventOfferSet)
                SerializeEventOfferSet(writer, eventOfferSet, serializer);
        }

        private void SerializeBoardEvent(JsonWriter writer, BoardEventInfo boardEvent, JsonSerializer serializer)
        {
            if (boardEvent.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, boardEvent.GetType(), boardEvent, serializer);
        }

        private void SerializeProgressionEvent(JsonWriter writer, ProgressionEventInfo progressionEvent, JsonSerializer serializer)
        {
            if (progressionEvent.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, progressionEvent.GetType(), progressionEvent, serializer);
        }

        private void SerializeCollectibleBoardEvent(JsonWriter writer, CollectibleBoardEventInfo collectibleEvent, JsonSerializer serializer)
        {
            if (collectibleEvent.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, collectibleEvent.GetType(), collectibleEvent, serializer);
        }

        private void SerializeLeaderboardEvent(JsonWriter writer, LeaderboardEventInfo leaderBoardEvent, JsonSerializer serializer)
        {
            if (leaderBoardEvent.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, leaderBoardEvent.GetType(), leaderBoardEvent, serializer);
        }

        private void SerializeShopEvent(JsonWriter writer, ShopEventInfo shopEvent, JsonSerializer serializer)
        {
            if (shopEvent.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, shopEvent.GetType(), shopEvent, serializer);
        }

        private void SerializeGarageCleanupEvent(JsonWriter writer, GarageCleanupEventInfo garageEvent, JsonSerializer serializer)
        {
            if (garageEvent.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, garageEvent.GetType(), garageEvent, serializer);
        }

        private void SerializeEventTask(JsonWriter writer, EventTaskInfo eventTask, JsonSerializer serializer)
        {
            if (eventTask.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, eventTask.GetType(), eventTask, serializer);
        }

        private void SerializeGarageCleanupRewardInfo(JsonWriter writer, GarageCleanupRewardInfo rewardInfo, JsonSerializer serializer)
        {
            if (rewardInfo.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, rewardInfo.GetType(), rewardInfo, serializer);
        }

        private void SerializeGarageCleanupBoardInfo(JsonWriter writer, GarageCleanupBoardInfo boardInfo, JsonSerializer serializer)
        {
            if (boardInfo.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, boardInfo.GetType(), boardInfo, serializer);
        }

        private void SerializeGarageCleanupBoardRowInfo(JsonWriter writer, GarageCleanupBoardRowInfo rowInfo, JsonSerializer serializer)
        {
            if (rowInfo.ConfigKey.BoardId.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, rowInfo.GetType(), rowInfo, serializer);
        }

        private void SerializeGarageCleanupPatternInfo(JsonWriter writer, GarageCleanupPatternInfo patternInfo, JsonSerializer serializer)
        {
            if (patternInfo.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, patternInfo.GetType(), patternInfo, serializer);
        }

        private void SerializeBoardCell(JsonWriter writer, BoardCell boardCell, JsonSerializer serializer)
        {
            if (boardCell.ItemId == 0)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, boardCell.GetType(), boardCell, serializer);
        }

        private void SerializeEventOfferSet(JsonWriter writer, EventOfferSetInfo eventOfferSet, JsonSerializer serializer)
        {
            if (eventOfferSet.EventOfferSetId.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, eventOfferSet.GetType(), eventOfferSet, serializer);
        }

        #region Task graph

        private string GetTaskGraph(BoardEventInfo board)
        {
            var nodes = GetTaskNodes(board);
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

            var res = string.Empty;

            if (LocMan.HasString(taskInfo.Description))
                res = LocMan.Get(taskInfo.Description).Replace("\"", "'");

            foreach (var req in taskInfo.Requirements)
                res += Environment.NewLine + LocMan.GetItemName(req.Item.ItemType) + " x" + req.Requirement;

            return res;
        }

        #endregion

        protected override void WriteCustomObjectMembers(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is BoardEventInfo boardEvent)
            {
                WriteProperty(writer, "TaskDependencies", GetTaskGraph(boardEvent), serializer);
                WriteProperty(writer, "Name", LocMan.Get(boardEvent.NameLocalizationId), serializer);
            }

            if (value is CollectibleBoardEventInfo collectibleEvent)
                WriteProperty(writer, "Name", LocMan.Get(collectibleEvent.NameLocId), serializer);

            if (value is ProgressionEventInfo progressionEvent)
                WriteProperty(writer, "Name", LocMan.Get(progressionEvent.NameLocId), serializer);

            if (value is LeaderboardEventInfo leaderboardEvent)
                WriteProperty(writer, "Name", LocMan.Get(leaderboardEvent.NameLocId), serializer);

            if (value is EventOfferSetInfo eventOfferSet)
                WriteProperty(writer, "Name", LocMan.Get(eventOfferSet.NameLocalizationId), serializer);

            if (value is EventTaskInfo eventTask)
                WriteProperty(writer, "TaskTitle", LocMan.Get(eventTask.TaskTitleLocId), serializer);

            if (value is GarageCleanupPatternInfo pattern)
            {
                var rewards = ClientGlobal.SharedGameConfig.GarageCleanupRewards;
                if (!rewards.TryGetValue(pattern.RewardId, out var reward))
                    return;

                WriteProperty(writer, "Reward", reward, serializer);
            }
        }

        protected override void WriteObjectMember(JsonWriter writer, string name, Type type, object value, JsonSerializer serializer)
        {
            #region Event types

            if (type.IsAssignableTo(typeof(BoardEventInfo)))
            {
                // TODO: Include story definitions
                if (name == nameof(BoardEventInfo.EventInitTask))
                {
                    WriteProperty(writer, name, (value as IMetaRef)?.KeyObject, serializer);
                    return;
                }
            }

            if (type.IsAssignableTo(typeof(ProgressionEventInfo)))
            {
                // TODO: Include story definitions
            }

            if (type.IsAssignableTo(typeof(CollectibleBoardEventInfo)))
            {
                if (name == nameof(CollectibleBoardEventInfo.EventInitTask))
                {
                    WriteProperty(writer, name, (value as IMetaRef)?.KeyObject, serializer);
                    return;
                }

                if (name == nameof(CollectibleBoardEventInfo.FallbackLevelRefs))
                {
                    writer.WritePropertyName(name);
                    writer.WriteStartObject();

                    var fallbackRefs = (Dictionary<MetaRef<EventLevelInfo>, MetaRef<EventLevelInfo>>)value;
                    foreach (var key in fallbackRefs.Keys)
                        WriteProperty(writer, key.Ref.ConfigKey.Value, fallbackRefs[key].Ref, serializer);

                    writer.WriteEndObject();

                    return;
                }
            }

            if (type.IsAssignableTo(typeof(ShopEventInfo)))
            {
                if (name == nameof(ShopEventInfo.HintedBoardEventInfos))
                {
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();

                    foreach (var task in (List<MetaRef<BoardEventInfo>>)value)
                        WriteValue(writer, task.KeyObject, serializer);

                    writer.WriteEndArray();

                    return;
                }
            }

            if (type.IsAssignableTo(typeof(GarageCleanupEventInfo)))
            {
                if (name == nameof(GarageCleanupEventInfo.SpawnerItems))
                {
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();

                    foreach (var item in (IList<int>)value)
                        WriteValue(writer, ClientGlobal.SharedGameConfig.Items.GetValueOrDefault(item)?.ItemType, serializer);

                    writer.WriteEndArray();

                    return;
                }
            }

            #endregion

            #region Generic event

            if (type.IsAssignableTo(typeof(EventTaskInfo)))
            {
                if (name == nameof(EventTaskInfo.UnlockTaskRefs))
                {
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();

                    foreach (var task in (List<MetaRef<EventTaskInfo>>)value)
                        WriteValue(writer, task.KeyObject, serializer);

                    writer.WriteEndArray();

                    return;
                }

                if (name == nameof(EventTaskInfo.Description))
                {
                    WriteProperty(writer, name, LocMan.GetEventDescription((string)value), serializer);

                    return;
                }
            }

            #endregion

            #region Garage Cleanup

            if (type.IsAssignableTo(typeof(GarageCleanupRewardInfo)))
            {
                if (name == nameof(GarageCleanupRewardInfo.VisualItem))
                {
                    WriteProperty(writer, name, (value as IMetaRef)?.KeyObject, serializer);
                    return;
                }
            }

            if (type.IsAssignableTo(typeof(GarageCleanupBoardInfo)))
            {
                if (name == nameof(GarageCleanupBoardInfo.Rows))
                {
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();

                    var boardRows = ClientGlobal.SharedGameConfig.GarageCleanupBoardRows;

                    foreach (var rowId in (IList<GarageCleanupBoardRowId>)value)
                    {
                        if (!boardRows.TryGetValue(rowId, out var rowInfo))
                            continue;

                        WriteObject(writer, rowInfo.GetType(), rowInfo, serializer);
                    }

                    writer.WriteEndArray();

                    return;
                }
            }

            if (type.IsAssignableTo(typeof(GarageCleanupBoardRowInfo)))
            {
                if (name == nameof(GarageCleanupBoardRowInfo.Items))
                {
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();

                    foreach (var item in (IList<MetaRef<ItemDefinition>>)value)
                        WriteValue(writer, item.Ref.ItemType, serializer);

                    writer.WriteEndArray();

                    return;
                }
            }

            if (type.IsAssignableTo(typeof(GarageCleanupPatternInfo)))
            {
                if (name == nameof(GarageCleanupPatternInfo.Rows))
                {
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();

                    var patternRows = ClientGlobal.SharedGameConfig.GarageCleanupPatternRows;

                    foreach (var rowId in (IList<GarageCleanupPatternRowId>)value)
                    {
                        if (!patternRows.TryGetValue(rowId, out var rowInfo))
                            continue;

                        WriteObject(writer, rowInfo.GetType(), rowInfo, serializer);
                    }

                    writer.WriteEndArray();

                    return;
                }
            }

            if (type.IsAssignableTo(typeof(BoardCell)))
            {
                if (name == nameof(BoardCell.ItemId))
                {
                    writer.WritePropertyName(name);
                    WriteValue(writer, ClientGlobal.SharedGameConfig.Items.GetValueOrDefault((int)value)?.ItemType, serializer);

                    return;
                }
            }

            #endregion

            base.WriteObjectMember(writer, name, type, value, serializer);
        }
    }
}
