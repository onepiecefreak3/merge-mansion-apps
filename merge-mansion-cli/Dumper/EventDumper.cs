using System;
using System.Collections.Generic;
using System.Linq;
using merge_mansion_cli.Dumper.Json;
using merge_mansion_cli.Dumper.Support;
using merge_mansion_cli.Graphs;
using merge_mansion_cli.Models.Area;
using merge_mansion_cli.Models.Events;
using Metaplay;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.GameLogic.Config;
using Metaplay.GameLogic.Player.Requirements;
using Metaplay.GameLogic.Story;
using Metaplay.Metaplay.Core.Schedule;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace merge_mansion_cli.Dumper
{
    class EventDumper : JsonDumper<IList<object>>
    {
        protected override IList<object> Dump(SharedGameConfig config)
        {
            return config.BoardEvents.EnumerateAll().Select(x => x.Value).Concat(config.ProgressionEvents.EnumerateAll().Select(x => x.Value)).ToList();
            //var res = new Dictionary<string, EventModel>();

            //foreach (var eventPair in config.BoardEvents.EnumerateAll())
            //    res[((EventId)eventPair.Key).Value] = GetEventModel((BoardEventInfo)eventPair.Value, config);
            //foreach (var eventPair in config.ProgressionEvents.EnumerateAll())
            //    res[((ProgressionEventId)eventPair.Key).Value] = GetEventModel((ProgressionEventInfo)eventPair.Value, config);

            //return res;
        }

        protected override JsonSerializerSettings CreateSettings(SharedGameConfig config)
        {
            return new JsonSerializerSettings(base.CreateSettings(config))
            {
                Converters =
                {
                    new MergeMansionJsonConverter(config, Output, false),
                    new StringEnumConverter()
                }
            };
        }

        private EventModel GetEventModel(BoardEventInfo eventInfo, SharedGameConfig config)
        {
            var model = new BoardEventModel
            {
                Name = eventInfo.DisplayName,
                Description = eventInfo.Description,
                EntranceItem = eventInfo.PortalItem,
                Duration = GetEventDuration(eventInfo.ActivableParams.Schedule),
                TaskDependencies = GetTaskGraph(eventInfo),
                Tasks = GetTasks(eventInfo)
            };

            var story = (StoryElementInfo)config.StoryElements.GetInfoByKey(eventInfo.StartEventDialogue);
            if (story == null)
                return model;

            foreach (var dialogItem in story.DialogItems)
            {
                model.Story ??= new List<DialogModel>();

                model.Story.Add(new DialogModel
                {
                    Speaker = dialogItem.Value.Ref.RightSpeaks ? dialogItem.Value.Ref.RightCharacter.ToString() : dialogItem.Value.Ref.LeftCharacter.ToString(),
                    Mood = dialogItem.Value.Ref.RightSpeaks ? dialogItem.Value.Ref.RightCharacterState.ToString() : dialogItem.Value.Ref.LeftCharacterState.ToString(),
                    Text = LocMan.Get(dialogItem.Value.Ref.LocalizationId)
                });
            }

            return model;
        }

        private EventModel GetEventModel(ProgressionEventInfo eventInfo, SharedGameConfig config)
        {
            var model = new ProgressionEventModel
            {
                Name = eventInfo.DisplayName,
                Description = eventInfo.Description,
                EventItem = eventInfo.EventItem,
                Duration = GetEventDuration(eventInfo.ActivableParams.Schedule),
                FreeRewards = eventInfo.FreeEventLevels?.Select(x => GetEventRewards((EventLevelInfo)config.EventLevels.GetInfoByKey(x))).ToArray(),
                PremiumRewards = eventInfo.PremiumEventLevels?.Select(x => GetEventRewards((EventLevelInfo)config.EventLevels.GetInfoByKey(x))).ToArray(),
            };

            var story = (StoryElementInfo)config.StoryElements.GetInfoByKey(eventInfo.IntroDialogue);
            foreach (var dialogItem in story.DialogItems)
            {
                model.Story ??= new List<DialogModel>();

                model.Story.Add(new DialogModel
                {
                    Speaker = dialogItem.Value.Ref.RightSpeaks ? dialogItem.Value.Ref.RightCharacter.ToString() : dialogItem.Value.Ref.LeftCharacter.ToString(),
                    Mood = dialogItem.Value.Ref.RightSpeaks ? dialogItem.Value.Ref.RightCharacterState.ToString() : dialogItem.Value.Ref.LeftCharacterState.ToString(),
                    Text = LocMan.Get(dialogItem.Value.Ref.LocalizationId)
                });
            }

            return model;
        }

        private EventLevelModel GetEventRewards(EventLevelInfo level)
        {
            return new EventLevelModel
            {
                ExpRequired = level.RequiredPoints,
                Rewards = RewardSupport.GetRewards(level.Rewards)
            };
        }

        private MetaCalendarPeriod GetEventDuration(MetaScheduleBase schedule)
        {
            switch (schedule)
            {
                case MetaRecurringCalendarSchedule rs:
                    return rs.Duration;

                default:
                    return new MetaCalendarPeriod();
            }
        }

        private IList<TaskModel> GetTasks(BoardEventInfo info)
        {
            var res = new List<TaskModel>();

            foreach (var task in info.EventTasks.Select(x => x.Ref))
            {
                var taskModel = new TaskModel
                {
                    Id = task.ConfigKey.Value,
                    Description = LocMan.Get(task.Description),
                    Rewards = RewardSupport.GetRewards(task.Rewards),
                    Requirements = RequirementSupport.GetRequirements(task.Requirements.Select(x => (PlayerRequirement)x).ToArray(), Output)
                };

                if (task.UnlockTaskRefs != null)
                    foreach (var unlocks in task.UnlockTaskRefs.Select(x => x.Ref))
                    {
                        taskModel.Unlocks ??= new List<string>();

                        taskModel.Unlocks.Add(unlocks.ConfigKey.Value);
                    }

                res.Add(taskModel);
            }

            return res;
        }

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

            foreach (var req in taskInfo.Requirements.Select(x => RequirementSupport.GetRequirement(x, Output)))
            {
                switch (req.Key)
                {
                    case RequirementType.ItemAcquired:
                        res += Environment.NewLine + "- " + LocMan.GetItemName(Enum.Parse<ItemType>(req.Value.Value)) + " x" + req.Value.Amount;
                        break;

                    //case RequirementType.Coins:
                    //    res += Environment.NewLine + "- Coins x" + req.Value.Amount;
                    //    break;

                    default:
                        throw new InvalidOperationException($"Unsupported requirement {req.Key}.");
                }
            }

            return res;
        }
    }
}
