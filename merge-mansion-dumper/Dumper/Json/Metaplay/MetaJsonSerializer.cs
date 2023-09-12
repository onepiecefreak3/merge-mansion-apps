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
using GameLogic.Player.Items;
using Metaplay.Core.Activables;
using Metaplay.Core.Player;
using Game.Logic;
using System.Security.Cryptography;
using GameLogic.Story;

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
                typeof(IMetaRef),
                typeof(MetaActivableLifetimeSpec),
                typeof(MetaActivableCooldownSpec),
                typeof(PlayerPropertyId),
                typeof(PlayerPropertyConstant),
                typeof(SurveyString),
                typeof(DialogItemInfo)
            };

        public MetaJsonSerializer(ILogger output)
        {
            _output = output;
        }

        protected override Type[] GetTypes() => _supportedTypes;

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is MetaDuration dur)
                WriteValue(writer, dur.Milliseconds, serializer);
            else if (value is MetaTime time)
                WriteValue(writer, time.ToDateTime(), serializer);
            else if (value is MetaCalendarDateTime calTime)
                WriteValue(writer, calTime.ToDateTime(), serializer);
            else if (value is MetaCalendarPeriod period)
                SerializePeriod(writer, period, serializer);
            else if (value is ContentHash hash)
                WriteValue(writer, hash.ToString(), serializer);
            else if (value is PlayerRequirement pr)
                SerializePlayerRequirement(writer, pr, serializer);
            else if (value is PlayerReward prew)
                SerializePlayerReward(writer, prew, serializer);
            else if (value is IDirectorAction dirAct)
                SerializeDirectorAction(writer, dirAct, serializer);
            else if (value is IStringId sId)
                WriteValue(writer, sId.Value, serializer);
            else if (value is IMetaRef metaRef)
                SerializeMetaRef(writer, metaRef, serializer);
            else if (value is MetaActivableLifetimeSpec activable)
                SerializeActivable(writer, activable, serializer);
            else if (value is MetaActivableCooldownSpec cooldown)
                SerializeActivableCooldown(writer, cooldown, serializer);
            else if (value is PlayerPropertyId propertyId)
                WriteValue(writer, propertyId.DisplayName, serializer);
            else if (value is PlayerPropertyConstant propertyConstant)
                WriteValue(writer, propertyConstant.ConstantValue, serializer);
            else if (value is SurveyString sSurvey)
                WriteValue(writer, sSurvey.Id, serializer);
            else if (value is DialogItemInfo dialogItemInfo)
                WriteObject(writer, dialogItemInfo.GetType(), dialogItemInfo, serializer);
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
                WriteProperty(writer, "ItemNeeded", inReq.ItemRef.Ref.ItemType, serializer);
            else if (requirement is ItemNeededAndConsumeRequirement inacReq)
                WriteProperty(writer, "ItemNeededAndConsumed", inacReq.ItemRefs.FirstOrDefault()?.Ref.ItemType ?? string.Empty, serializer);
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

                WriteProperty(writer, "ItemRef", piReq.Item.ItemType, serializer);
                WriteProperty(writer, "Requirement", piReq.Requirement, serializer);

                writer.WriteEndObject();
            }
            else if (requirement is PlayerSeenItemRequirement psiReq)
            {
                writer.WritePropertyName("ItemSeen");
                writer.WriteStartObject();

                WriteProperty(writer, "ItemRef", psiReq.ItemRef.ItemType, serializer);
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

            if (directorAction is TriggerDialogue triggerDialogueAction)
            {
                var storyElements = ClientGlobal.SharedGameConfig.StoryElements;
                if (storyElements.TryGetValue(triggerDialogueAction.StoryDefinitionId, out var element))
                    WriteObject(writer, element.GetType(), element, serializer);
                else
                    writer.WriteNull();
            }
            else
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

        private void SerializeActivable(JsonWriter writer, MetaActivableLifetimeSpec activable, JsonSerializer serializer)
        {
            if (activable is MetaActivableLifetimeSpec.Fixed fixedAct)
                WriteValue(writer, fixedAct.Duration, serializer);
            else if (activable is MetaActivableLifetimeSpec.ScheduleBased)
                WriteValue(writer, nameof(MetaActivableLifetimeSpec.ScheduleBased), serializer);
            else if (activable is MetaActivableLifetimeSpec.Forever)
                WriteValue(writer, nameof(MetaActivableLifetimeSpec.Forever), serializer);
            else
            {
                writer.WriteNull();
                _output.Warning("Unknown ActivableLifetime {0}", activable.GetType().Name);
            }
        }

        private void SerializeActivableCooldown(JsonWriter writer, MetaActivableCooldownSpec cooldown, JsonSerializer serializer)
        {
            if (cooldown is MetaActivableCooldownSpec.Fixed fixedAct)
                WriteValue(writer, fixedAct.Duration, serializer);
            else if (cooldown is MetaActivableCooldownSpec.ScheduleBased)
                WriteValue(writer, nameof(MetaActivableCooldownSpec.ScheduleBased), serializer);
            else
            {
                writer.WriteNull();
                _output.Warning("Unknown ActivableCooldown {0}", cooldown.GetType().Name);
            }
        }

        protected override void WriteCustomObjectMembers(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DialogItemInfo dialogItemInfo)
                WriteProperty(writer, "Text", LocMan.Get(dialogItemInfo.LocalizationId), serializer);
        }

        protected override void WriteObjectMember(JsonWriter writer, string name, Type type, object value, JsonSerializer serializer)
        {
            if (type.IsAssignableTo(typeof(PlayerReward)))
            {
                if (name == "ItemRef")
                {
                    WriteProperty(writer, name, (value as MetaRef<ItemDefinition>)?.Ref.ItemType, serializer);
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
