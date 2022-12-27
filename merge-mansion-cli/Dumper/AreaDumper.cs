using System;
using System.Collections.Generic;
using System.Linq;
using merge_mansion_cli.Dumper.Support;
using merge_mansion_cli.Graphs;
using merge_mansion_cli.Models.Area;
using Metaplay;
using Metaplay.GameLogic.Area;
using Metaplay.GameLogic.Config;
using Metaplay.GameLogic.Hotspots;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.GameLogic.Story;
using Metaplay.Metaplay.Core;
using MoreLinq;

namespace merge_mansion_cli.Dumper
{
    class AreaDumper : JsonDumper<IList<AreaModel>>
    {
        protected override IList<AreaModel> Dump(SharedGameConfig config)
        {
            var result = new List<AreaModel>();

            foreach (var area in config.Areas.EnumerateAll())
                result.Add(CreateAreaModel((AreaInfo)area.Value, config));

            return result;
        }

        private AreaModel CreateAreaModel(AreaInfo area, SharedGameConfig config)
        {
            var res = new AreaModel
            {
                Id = area.AreaId.Value,
                Name = LocMan.GetHotspotTitle(area.AreaId),
                TaskDependencies = GetTaskGraph(area, config),
                Tasks = GetTasks(area.HotspotsRefs, config),
                Rewards = RewardSupport.GetRewards(area.Rewards),
                UnlockAt = RequirementSupport.GetRequirements(area.UnlockRequirements, Output),
                TeaseAt = RequirementSupport.GetRequirements(area.TeaseRequirements, Output)
            };

            return res;
        }

        private IList<TaskModel> GetTasks(IList<MetaRef<HotspotDefinition>> tasks, SharedGameConfig config)
        {
            var res = new List<TaskModel>();

            foreach (var task in tasks.Where(x => x.Ref.ConfigKey != HotspotId.None).Select(x => x.Ref))
            {
                var taskModel = new TaskModel
                {
                    Id = task.Id.ToString(),
                    Description = LocMan.GetHotspotDescription(task.Id),
                    Rewards = RewardSupport.GetRewards(task.Rewards),
                    Requirements = RequirementSupport.GetRequirements(task.RequirementsList, Output)
                };

                foreach (var unlocks in task.OpensAfterCompletion)
                {
                    taskModel.Unlocks ??= new List<string>();

                    taskModel.Unlocks.Add(unlocks.ToString());
                }

                foreach (var completeAction in task.CompletionActions)
                {
                    if (!(completeAction is TriggerDialogue td))
                        continue;

                    var story = (StoryElementInfo)config.StoryElements.GetInfoByKey(td.DialogueId);
                    foreach (var dialogItem in story.DialogItems)
                    {
                        taskModel.Story ??= new List<DialogModel>();

                        taskModel.Story.Add(new DialogModel
                        {
                            Speaker = dialogItem.Value.Ref.RightSpeaks ? dialogItem.Value.Ref.RightCharacter.ToString() : dialogItem.Value.Ref.LeftCharacter.ToString(),
                            Mood = dialogItem.Value.Ref.RightSpeaks ? dialogItem.Value.Ref.RightCharacterState.ToString() : dialogItem.Value.Ref.LeftCharacterState.ToString(),
                            Text = LocMan.Get(dialogItem.Value.Ref.LocalizationId)
                        });
                    }
                }

                res.Add(taskModel);
            }

            return res;
        }

        private string GetTaskGraph(AreaInfo area, SharedGameConfig config)
        {
            var nodes = GetTaskNodes(area, config);
            return GraphViz.GetGraph(nodes);
        }

        private IList<Node> GetTaskNodes(AreaInfo area, SharedGameConfig config)
        {
            var hotspotDict = new Dictionary<HotspotId, Node>();
            foreach (var hotspot in area.HotspotsRefs.DistinctBy(x => x.Ref.ConfigKey).Where(x => x.Ref.ConfigKey != HotspotId.None))
            {
                if (!hotspotDict.TryGetValue(hotspot.Ref.ConfigKey, out var node))
                    node = new Node { Text = GetNodeText(hotspot.Ref) };

                foreach (var unlockChild in hotspot.Ref.OpensAfterCompletion)
                {
                    if (!hotspotDict.TryGetValue(unlockChild, out var unlockChildNode))
                        hotspotDict[unlockChild] = unlockChildNode = new Node { Text = GetNodeText((HotspotDefinition)config.HotspotDefinitions.EnumerateAll().FirstOrDefault(x => (HotspotId)x.Key == unlockChild).Value) };

                    node.AddChild(unlockChildNode);
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

            foreach (var req in hotspot.RequirementsList.Select(x => RequirementSupport.GetRequirement(x, Output)))
            {
                switch (req.Key)
                {
                    case RequirementType.ItemAcquired:
                        res += Environment.NewLine + "- " + LocMan.GetItemName(Enum.Parse<ItemType>(req.Value.Value)) + " x" + req.Value.Amount;
                        break;

                    case RequirementType.Coins:
                        res += Environment.NewLine + "- Coins x" + req.Value.Amount;
                        break;
                }
            }

            return res;
        }
    }
}
