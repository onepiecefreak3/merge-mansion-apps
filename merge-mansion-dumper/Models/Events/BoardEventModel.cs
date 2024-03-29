﻿using System.Collections.Generic;
using GameLogic;
using merge_mansion_dumper.Models.Area;
using Metaplay.Core.Schedule;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace merge_mansion_dumper.Models.Events
{
    public abstract class EventModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract EventType? EventType { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<DialogModel> Story { get; set; }
        public MetaCalendarPeriod Duration { get; set; }
    }

    public class BoardEventModel : EventModel
    {
        public override EventType? EventType => Events.EventType.Board;

        [JsonConverter(typeof(StringEnumConverter))]
        public ItemTypeConstant? EntranceItem { get; set; }

        public string TaskDependencies { get; set; }
        public IList<TaskModel> Tasks { get; set; }
    }

    public class ProgressionEventModel : EventModel
    {
        public override EventType? EventType => Events.EventType.Progression;

        [JsonConverter(typeof(StringEnumConverter))]
        public ItemTypeConstant? EventItem { get; set; }

        public IList<EventLevelModel> FreeRewards { get; set; }
        public IList<EventLevelModel> PremiumRewards { get; set; }
    }

    public class EventLevelModel
    {
        public int ExpRequired { get; set; }
        public IList<RewardModel> Rewards { get; set; }
    }

    public enum EventType
    {
        Board,
        Progression
    }
}
