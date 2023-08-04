namespace Metaplay.Core
{
    public class MetaLogLevelSwitch
    {
        private LogLevel _minimumLevel;
        public LogLevel MinimumLevel { get; set; }

        public MetaLogLevelSwitch(LogLevel level)
        {
        }
    }
}