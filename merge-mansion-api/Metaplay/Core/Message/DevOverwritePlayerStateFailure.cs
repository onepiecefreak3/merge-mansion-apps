using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Message
{
    [MetaSerializableDerived(4)]
    public class DevOverwritePlayerStateFailure : MetaResponse
    {
        public string Reason;
        public DevOverwritePlayerStateFailure()
        {
        }

        public DevOverwritePlayerStateFailure(string failureReason)
        {
        }
    }
}