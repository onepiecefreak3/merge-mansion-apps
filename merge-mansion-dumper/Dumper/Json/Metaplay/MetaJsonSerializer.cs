using GameLogic.Player.Director.Config;
using GameLogic.Player.Requirements;
using GameLogic.Player.Rewards;
using Metaplay.Core.Schedule;
using Metaplay.Core;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using GameLogic;

namespace merge_mansion_dumper.Dumper.Json.Metaplay
{
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
                WriteProperty(writer, "AreaCompleted", aReq.AreaRef.KeyObject, serializer);
            else if (requirement is HotspotCompletedRequirement hReq)
                WriteProperty(writer, "HotspotCompleted", hReq.GetRequiredHotspot().KeyObject, serializer);
            else if (requirement is HotspotVisibleOrCompletedRequirement hvcReq)
                WriteProperty(writer, "HotspotVisibleOrCompleted", hvcReq.GetRequiredHotspot().KeyObject, serializer);
            else if (requirement is HotspotVisibleRequirement hvReq)
                WriteProperty(writer, "HotspotVisible", hvReq.GetRequiredHotspot().KeyObject, serializer);
            else if (requirement is CostRequirement cReq)
                WriteProperty(writer, "RequiredCost", cReq.RequiredCost, serializer);
            else if (requirement is ItemNeededRequirement inReq)
                WriteProperty(writer, "ItemNeeded", (ItemTypeConstant)inReq.ItemRef.KeyObject, serializer);
            else if (requirement is ItemNeededAndConsumeRequirement inacReq)
                WriteProperty(writer, "ItemNeededAndConsumed", (ItemTypeConstant)(inacReq.ItemRefs.FirstOrDefault()?.KeyObject ?? 0), serializer);
            else if (requirement is MergeChainItemNeededRequirement mciReq)
            {
                writer.WritePropertyName("MergeChainItemNeeded");
                writer.WriteStartObject();

                WriteProperty(writer, "MergeChainRef", mciReq.MergeChainRef.KeyObject, serializer);
                if (mciReq.MinLevel.HasValue)
                    WriteProperty(writer, "MinLevel", mciReq.MinLevel, serializer);
                if (mciReq.MaxLevel.HasValue)
                    WriteProperty(writer, "MaxLevel", mciReq.MaxLevel, serializer);

                writer.WriteEndObject();
            }
            else if (requirement is PlayerItemRequirement piReq)
            {
                writer.WritePropertyName("ItemAcquired");
                writer.WriteStartObject();

                WriteProperty(writer, "ItemRef", (ItemTypeConstant)piReq.Item.ConfigKey, serializer);
                WriteProperty(writer, "Requirement", piReq.Requirement, serializer);

                writer.WriteEndObject();
            }
            else if (requirement is PlayerSeenItemRequirement psiReq)
            {
                writer.WritePropertyName("ItemSeen");
                writer.WriteStartObject();

                WriteProperty(writer, "ItemRef", (ItemTypeConstant)psiReq.ItemRef.KeyObject, serializer);
                WriteProperty(writer, "Requirement", psiReq.Requirement, serializer);

                writer.WriteEndObject();
            }
            else if (requirement is PlayerLevelRequirement plReq)
            {
                writer.WritePropertyName("LevelNeeded");
                writer.WriteStartObject();

                if (plReq.Min.HasValue)
                    WriteProperty(writer, "Min", plReq.Min, serializer);
                if (plReq.Max.HasValue)
                    WriteProperty(writer, "Max", plReq.Max, serializer);

                writer.WriteEndObject();
            }
            else if (requirement is PlayerCurrentTimeRequirement pctReq)
            {
                writer.WritePropertyName("TimeNeeded");
                writer.WriteStartObject();

                if (pctReq.StartInclusive.HasValue)
                    WriteProperty(writer, "StartInclusive", pctReq.StartInclusive, serializer);
                if (pctReq.EndExclusive.HasValue)
                    WriteProperty(writer, "EndExclusive", pctReq.EndExclusive, serializer);

                writer.WriteEndObject();
            }
            else
                _output.Warning("Unknown requirement {0}", requirement.GetType().Name);

            writer.WriteEndObject();
        }

        private void SerializePlayerReward(JsonWriter writer, PlayerReward rewardItem, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(rewardItem.GetType().Name);
            WriteObject(writer, rewardItem.GetType(), rewardItem, serializer);

            writer.WriteEndObject();
        }

        private void SerializeDirectorAction(JsonWriter writer, IDirectorAction directorAction, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(directorAction.GetType().Name);
            WriteObject(writer, directorAction.GetType(), directorAction, serializer);

            writer.WriteEndObject();
        }

        private void SerializeMetaRef(JsonWriter writer, IMetaRef metaRef, JsonSerializer serializer)
        {
            if (!metaRef.IsResolved)
            {
                serializer.Serialize(writer, metaRef.KeyObject);
                return;
            }

            serializer.Serialize(writer, metaRef.GetType().GetProperty("Ref")?.GetValue(metaRef));
        }

        protected override void WriteObjectMember(JsonWriter writer, string name, Type type, object value, JsonSerializer serializer)
        {
            if (type.IsAssignableTo(typeof(PlayerReward)))
            {
                if (name == "ItemRef")
                {
                    WriteProperty(writer, name, (ItemTypeConstant)((value as IMetaRef)?.KeyObject ?? 0), serializer);
                    return;
                }
                
                if (name == "EventInfoRef")
                {
                    WriteProperty(writer, name, (value as IMetaRef)?.KeyObject, serializer);
                    return;
                }
            }

            base.WriteObjectMember(writer, name, type, value, serializer);
        }
    }
}
