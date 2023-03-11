using Metaplay.GameLogic.Config;
using Serilog;

namespace merge_mansion_cli.Dumper.Base
{
    abstract class BaseDumper<TDump>
    {
        protected ILogger Output { get; } = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        public abstract TDump Dump(SharedGameConfig config);
    }
}
