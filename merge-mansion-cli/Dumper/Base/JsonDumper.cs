﻿using System.IO;
using merge_mansion_cli.Dumper.Base;
using Metaplay.GameLogic.Config;
using Newtonsoft.Json;

namespace merge_mansion_cli.Dumper
{
    abstract class JsonDumper<TDump> : BaseDumper<TDump>
    {
        public void WriteJson(string file, SharedGameConfig config)
        {
            var dump = Dump(config);
            File.WriteAllText(file, JsonConvert.SerializeObject(dump, Formatting.Indented, CreateSettings(config)));
        }

        protected virtual JsonSerializerSettings CreateSettings(SharedGameConfig config) => new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
    }
}
