using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializable]
    public class AuthenticationKey
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public AuthenticationPlatform Platform;
        [MetaMember(2, (MetaMemberFlags)0)]
        public string Id;
        public AuthenticationKey()
        {
        }

        public AuthenticationKey(AuthenticationPlatform platform, string userId)
        {
        }
    }
}