using System.IO;
using GameLogic.Config;
using Newtonsoft.Json;

namespace merge_mansion_dumper.Dumper.Base
{
    abstract class JsonDumper<TDump> : BaseDumper<TDump>
    {
        public void WriteJson(string file, SharedGameConfig config)
        {
            var dump = Dump(config);
            var data = new { CreatedAt = config.ArchiveCreatedAt, Data = dump };

            var dir = Path.GetDirectoryName(file);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllText(file, JsonConvert.SerializeObject(data, Formatting.Indented, CreateSettings(config)));
        }

        protected virtual JsonSerializerSettings CreateSettings(SharedGameConfig config) => new() { NullValueHandling = NullValueHandling.Ignore };
    }
}
