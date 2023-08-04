using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public class GameConfigBuildLog
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<GameConfigBuildLog.LogEntry> Entries { get; set; }
        public bool HasBlockingEntries { get; }

        public GameConfigBuildLog()
        {
        }

        public GameConfigBuildLog(IEnumerable<GameConfigBuildLog.VariantEntries> results)
        {
        }

        [MetaSerializable]
        public class LogEntry
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public string Message { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public string Library { get; set; }

            [MetaMember(3, (MetaMemberFlags)0)]
            public string Row { get; set; }

            [MetaMember(4, (MetaMemberFlags)0)]
            public string Column { get; set; }

            [MetaMember(5, (MetaMemberFlags)0)]
            public string Hint { get; set; }

            [MetaMember(6, (MetaMemberFlags)0)]
            public int Count { get; set; }

            [MetaMember(7, (MetaMemberFlags)0)]
            public List<string> Variants { get; set; }

            [MetaMember(8, (MetaMemberFlags)0)]
            public BuildLogCode BuildLogCode { get; set; }

            [MetaMember(9, (MetaMemberFlags)0)]
            public BuildLogLevel LogLevel { get; set; }

            public LogEntry()
            {
            }

            public LogEntry(GameConfigBuildLog.InternalLogEntry internalLogEntry, string variant)
            {
            }
        }

        public class InternalLogEntry
        {
            public string Message;
            public BuildLogCode BuildLogCode;
            public BuildLogLevel LogLevel;
            public string Library;
            public string Row;
            public string Column;
            public string Hint;
            public InternalLogEntry(string message, BuildLogCode buildLogCode, BuildLogLevel logLevel, string library, string row, string column, string hint)
            {
            }
        }

        public class VariantEntries
        {
            public string Id { get; set; }
            public List<GameConfigBuildLog.InternalLogEntry> Entries { get; set; }
            public List<Predicate<GameConfigBuildLog.InternalLogEntry>> Filters { get; set; }

            public VariantEntries()
            {
            }

            public VariantEntries(string variantId)
            {
            }
        }
    }
}