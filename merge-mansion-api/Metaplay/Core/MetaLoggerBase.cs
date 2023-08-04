using System;

namespace Metaplay.Core
{
    public abstract class MetaLoggerBase : IMetaLogger
    {
        public bool IsVerboseEnabled { get; }
        public bool IsDebugEnabled { get; }
        public bool IsInformationEnabled { get; }
        public bool IsWarningEnabled { get; }
        public bool IsErrorEnabled { get; }

        protected MetaLoggerBase()
        {
        }
    }
}