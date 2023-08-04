using Code.GameLogic.GameEvents;
using merge_mansion_dumper.Graphs;
using Metaplay.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private void SerializeEventTask(JsonWriter writer, EventTaskInfo eventTask, JsonSerializer serializer)
        {
            if (eventTask.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, eventTask.GetType(), eventTask, serializer);
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

            var res = string.Empty;

            if (LocMan.HasString(taskInfo.Description))
                res = LocMan.Get(taskInfo.Description).Replace("\"", "'");

            foreach (var req in taskInfo.Requirements)
                res += Environment.NewLine + LocMan.GetItemName(req.Item.ConfigKey) + " x" + req.Requirement;

            return res;
        }

        #endregion

        protected override void WriteCustomObjectMembers(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is BoardEventInfo boardEvent)
            {
                WriteProperty(writer, "TaskDependencies", GetTaskGraph(boardEvent), serializer);
            }
        }

        protected override void WriteObjectMember(JsonWriter writer, string name, Type type, object value, JsonSerializer serializer)
        {
            if (type.IsAssignableTo(typeof(BoardEventInfo)))
            {
                // TODO: Include story definitions
                if (name == nameof(BoardEventInfo.EventInitTask))
                {
                    WriteProperty(writer, name, (value as IMetaRef)?.KeyObject, serializer);
                    return;
                }
            }
            else if (type.IsAssignableTo(typeof(ProgressionEventInfo)))
            {
                // TODO: Include story definitions
            }
            else if (type.IsAssignableTo(typeof(CollectibleBoardEventInfo)))
            {
                if (name == nameof(CollectibleBoardEventInfo.EventInitTask))
                {
                    WriteProperty(writer, name, (value as IMetaRef)?.KeyObject, serializer);
                    return;
                }
            }
            else if (type.IsAssignableTo(typeof(ShopEventInfo)))
            {
                if (name == nameof(ShopEventInfo.HintedBoardEventInfos))
                {
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();

                    foreach (var task in (List<MetaRef<BoardEventInfo>>)value)
                        serializer.Serialize(writer, task.KeyObject);

                    writer.WriteEndArray();

                    return;
                }
            }
            else if (type.IsAssignableTo(typeof(EventTaskInfo)))
            {
                if (name == nameof(EventTaskInfo.UnlockTaskRefs))
                {
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();

                    foreach (var task in (List<MetaRef<EventTaskInfo>>)value)
                        serializer.Serialize(writer, task.KeyObject);

                    writer.WriteEndArray();

                    return;
                }
            }

            base.WriteObjectMember(writer, name, type, value, serializer);
        }
    }
}
