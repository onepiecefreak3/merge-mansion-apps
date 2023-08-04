using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Message
{
    [MetaSerializableDerived(3)]
    public class DevOverwritePlayerStateRequest : MetaRequest
    {
        public string EntityArchiveJson { get; set; }

        public DevOverwritePlayerStateRequest()
        {
        }

        public DevOverwritePlayerStateRequest(string json)
        {
        }
    }
}