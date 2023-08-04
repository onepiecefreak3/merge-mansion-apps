using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Debugging
{
    [MetaSerializable]
    public class ClientLogEntry
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime Timestamp { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public ClientLogEntryType Level { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Message { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string StackTrace { get; set; }

        public ClientLogEntry()
        {
        }

        public ClientLogEntry(MetaTime timestamp, ClientLogEntryType level, string message, string stackTrace)
        {
        }
    }
}