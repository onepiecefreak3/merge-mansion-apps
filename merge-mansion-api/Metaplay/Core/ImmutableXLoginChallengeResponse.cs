using Metaplay.Core.Model;
using Metaplay.Core.Message;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(6)]
    public class ImmutableXLoginChallengeResponse : MetaResponse
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public EntityId PlayerId { get; set; }
        public MetaTime Timestamp { get; set; }

        private ImmutableXLoginChallengeResponse()
        {
        }

        public ImmutableXLoginChallengeResponse(string message, string description, EntityId playerId, MetaTime timestamp)
        {
        }
    }
}