using Metaplay.Core.Model;
using Metaplay.Core.Message;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(5)]
    public class ImmutableXLoginChallengeRequest : MetaRequest
    {
        public string ClaimedImmutableXAccount { get; set; }
        public string ClaimedEthereumAccount { get; set; }

        private ImmutableXLoginChallengeRequest()
        {
        }

        public ImmutableXLoginChallengeRequest(string claimedImmutableXAccount, string claimedEthereumAccount)
        {
        }
    }
}