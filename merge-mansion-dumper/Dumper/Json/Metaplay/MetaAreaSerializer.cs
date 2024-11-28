using GameLogic.Area;
using GameLogic.Config.Costs;
using GameLogic.Config;
using GameLogic.Hotspots;
using GameLogic.Player.Requirements;
using merge_mansion_dumper.Graphs;
using Metaplay.Core;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Game.Cloud.Config;
using GameLogic;
using GameLogic.Player.Items;

namespace merge_mansion_dumper.Dumper.Json.Metaplay
{
    class MetaAreaSerializer : BaseMetaJsonSerializer
    {
        private readonly SharedGameConfig _config;
        private readonly ILogger _output;

        private readonly Type[] _supportedTypes =
        {
            typeof(AreaInfo),
            typeof(HotspotDef),
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
            else if (value is HotspotDef hotspotDef)
                SerializeHotspotDef(writer, hotspotDef, serializer);
            else if (value is HotspotDefinition hotspot)
                SerializeHotspot(writer, hotspot, serializer);
        }

        private void SerializeArea(JsonWriter writer, AreaInfo area, JsonSerializer serializer)
        {
            if (area.ConfigKey.Value == null)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, area.GetType(), area, serializer);
        }

        private void SerializeHotspotDef(JsonWriter writer, HotspotDef hotspotDef, JsonSerializer serializer)
        {
            if (!Enum.IsDefined(hotspotDef.ConfigKey))
                _output.Warning(Program.VersionBumped ? "HotspotId {0} unknown" : "[Metacore] HotspotId {0} unknown", hotspotDef.ConfigKey);

            if (hotspotDef.ConfigKey == HotspotId.None)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, typeof(HotspotDefinition), _config.HotspotDefinitions.GetInfoByKey(hotspotDef.ConfigKey), serializer);
        }

        private void SerializeHotspot(JsonWriter writer, HotspotDefinition hotspot, JsonSerializer serializer)
        {
            if (!Enum.IsDefined(hotspot.ConfigKey))
                _output.Warning(Program.VersionBumped ? "HotspotId {0} unknown" : "[Metacore] HotspotId {0} unknown", hotspot.ConfigKey);

            if (hotspot.ConfigKey == HotspotId.None)
            {
                WriteEmptyObject(writer);
                return;
            }

            WriteObject(writer, hotspot.GetType(), hotspot, serializer);
        }

        #region Task graphs

        private string GetTaskGraph(IList<HotspotDef> hotspots)
        {
            var nodes = GetTaskNodes(hotspots);
            return GraphViz.GetGraph(nodes);
        }

        private IList<Node> GetTaskNodes(IList<HotspotDef> hotspotDefs)
        {
            var hotspots = hotspotDefs.Select(h => (HotspotDefinition)_config.HotspotDefinitions.GetInfoByKey(h.ConfigKey));

            var hotspotDict = new Dictionary<HotspotId, Node>();
            foreach (var hotspot in hotspots.Where(x => x.ConfigKey != HotspotId.None).OrderBy(x => x.ConfigKey))
            {
                if (!hotspotDict.TryGetValue(hotspot.ConfigKey, out var node))
                    node = new Node { Text = GetNodeText(hotspot) };

                foreach (var unlockParent in hotspot.UnlockingParentRefs)
                {
                    if (!hotspotDict.TryGetValue(unlockParent.ConfigKey, out var unlockParentNode))
                        hotspotDict[unlockParent.ConfigKey] = unlockParentNode = new Node { Text = GetNodeText((HotspotDefinition)_config.HotspotDefinitions.EnumerateAll().FirstOrDefault(x => (HotspotId)x.Key == unlockParent.ConfigKey).Value) };

                    unlockParentNode.AddChild(node);
                }

                hotspotDict[hotspot.ConfigKey] = node;
            }

            return hotspotDict.Values.ToArray();
        }


        private string GetNodeText(HotspotDefinition hotspot)
        {
            if (hotspot == null)
                return null;

            var description = string.Empty;
            if (LocMan.HasString(LocMan.GetHotspotDescriptionLocId(hotspot.Id)))
                description = LocMan.GetHotspotDescription(hotspot.Id).Replace('"','\'');

            var res = hotspot.ConfigKey + Environment.NewLine + description;

            foreach (var req in hotspot.RequirementsList)
            {
                if (req is PlayerItemRequirement pir)
                    res += string.Join(Environment.NewLine, pir.Items.Select(i=> LocMan.GetItemName(((ItemDefinition)_config.Items.GetInfoByKey(i)).ItemType).Replace('"', '\'') + " x" + pir.Requirement));
                else if (req is CostRequirement cr && cr.RequiredCost is CurrencyCost cc)
                    res += Environment.NewLine + "Coins x" + cc.CurrencyAmount;
            }

            return res;
        }

        #endregion

        protected override void WriteCustomObjectMembers(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is AreaInfo area)
            {
                var areaName = LocMan.GetHotspotTitle(area.AreaId.Value);
                if (areaName != null)
                    WriteProperty(writer, "Name", areaName, serializer);

                var hotspots = area.HotspotsRefs.DistinctBy(x => x.ConfigKey).ToArray();
                if (area.HotspotsRefs.Count != hotspots.Length)
                    _output.Warning("[Metacore] Area {0} has {1} duplicated tasks.", area.ConfigKey, area.HotspotsRefs.Count - hotspots.Length);

                WriteProperty(writer, "TaskDependencies", GetTaskGraph(hotspots), serializer);
            }
            else if (value is HotspotDefinition hotspot)
            {
                if (LocMan.HasString(LocMan.GetHotspotDescriptionLocId(hotspot.Id)))
                    WriteProperty(writer, "Description", LocMan.GetHotspotDescription(hotspot.Id), serializer);
            }
        }

        protected override void WriteObjectMember(JsonWriter writer, string name, Type type, object value, JsonSerializer serializer)
        {
            if (type.IsAssignableTo(typeof(AreaInfo)))
            {
                if (name == nameof(AreaInfo.UnlockingHotspotRef))
                {
                    WriteProperty(writer, name, (value as IMetaRef)?.KeyObject, serializer);
                    return;
                }

                if (name == nameof(AreaInfo.HotspotsRefs))
                {
                    var hotspots = (value as List<HotspotDef>).DistinctBy(x => x.ConfigKey).ToArray();
                    WriteProperty(writer, name, hotspots, serializer);

                    return;
                }
            }
            else if (type.IsAssignableTo(typeof(HotspotDefinition)))
            {
                if (name == nameof(HotspotDefinition.AreaRef))
                {
                    WriteProperty(writer, name, (value as IMetaRef)?.KeyObject, serializer);
                    return;
                }
                if (name == nameof(HotspotDefinition.UnlockingParentRefs))
                {
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();

                    foreach (var task in (List<HotspotDef>)value)
                        serializer.Serialize(writer, task.ConfigKey);

                    writer.WriteEndArray();

                    return;
                }
            }

            base.WriteObjectMember(writer, name, type, value, serializer);
        }
    }
}
