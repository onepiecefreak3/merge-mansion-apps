﻿using System.Collections.Generic;
using System.Linq;
using GameLogic.Config;
using merge_mansion_dumper.Dumper.Base;
using merge_mansion_dumper.Dumper.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace merge_mansion_dumper.Dumper
{
    class EventDumper : JsonDumper<IDictionary<string, object>>
    {
        public override IDictionary<string, object> Dump(SharedGameConfig config)
        {
            var events = new Dictionary<string, object>
            {
                ["Boards"] = config.BoardEvents.EnumerateAll().Select(x => x.Value).ToArray(),
                ["CollectibleBoards"] = config.CollectibleBoardEvents.EnumerateAll().Select(x => x.Value).ToArray(),
                ["Progressions"] = config.ProgressionEvents.EnumerateAll().Select(x => x.Value).ToArray(),
                ["Leaderboards"] = config.LeaderboardEvents.EnumerateAll().Select(x => x.Value).ToArray(),
                ["GarageCleanups"] = config.GarageCleanupEvents.EnumerateAll().Select(x => x.Value).ToArray(),
                ["Shops"] = config.ShopEvents.EnumerateAll().Select(x => x.Value).ToArray(),
                ["DailyTasks"] = config.DailyTasks.EnumerateAll().Select(x => x.Value).ToArray(),
                ["DailyTasksV2"] = config.DailyTasksV2.EnumerateAll().Select(x => x.Value).ToArray()
            };

            return events;
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
    }
}
