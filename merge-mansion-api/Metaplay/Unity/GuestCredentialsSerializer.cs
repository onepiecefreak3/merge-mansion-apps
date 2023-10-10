using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace Metaplay.Unity
{
    public abstract class GuestCredentialsSerializer
    {
        [MetaSerializable]
        public class CredentialsData
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public string DeviceId;
            [MetaMember(2, (MetaMemberFlags)0)]
            public string AuthToken;
            [MetaMember(3, (MetaMemberFlags)0)]
            public EntityId PlayerId;
            public CredentialsData()
            {
            }
        }
    }
}