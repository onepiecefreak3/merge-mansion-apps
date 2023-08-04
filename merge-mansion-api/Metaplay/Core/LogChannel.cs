using System;

namespace Metaplay.Core
{
    public class LogChannel : MetaLoggerBase
    {
        public string Name { get; set; }
        public IMetaLogger Logger { get; set; }
        public MetaLogLevelSwitch ChannelLevel { get; set; }
        public static LogChannel Empty { get; }

        public LogChannel(string name, IMetaLogger logger, MetaLogLevelSwitch channelLevel)
        {
        }
    }
}