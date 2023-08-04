using System;

namespace Metaplay.Core
{
    public interface IMetaLogger
    {
        bool IsVerboseEnabled { get; }

        bool IsDebugEnabled { get; }

        bool IsInformationEnabled { get; }

        bool IsWarningEnabled { get; }

        bool IsErrorEnabled { get; }
    }
}