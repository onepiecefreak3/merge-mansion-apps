using System.IO;
using Metaplay.GameLogic.Config;
using Newtonsoft.Json;

namespace merge_mansion_cli.Dumper.Base
{
    abstract class JsonDumper<TDump> : BaseDumper<TDump>
    {
        public void WriteJson(string file, SharedGameConfig config)
        {
            var dump = Dump(config);

            var dir = Path.GetDirectoryName(file);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllText(file, JsonConvert.SerializeObject(dump, Formatting.Indented, CreateSettings(config)));
        }

        protected virtual JsonSerializerSettings CreateSettings(SharedGameConfig config) => new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
    }
}
