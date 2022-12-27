using Metaplay.GameLogic.Config;
using Metaplay.Metaplay.Core.Localization;
using Serilog;

namespace merge_mansion_cli.Dumper.Base
{
    abstract class BaseDumper<TDump>
    {
        protected ILogger Output { get; } = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        protected abstract TDump Dump(SharedGameConfig config);
    }
}
