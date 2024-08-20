using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Client
{
    [MetaSerializable]
    public class EntityDebugConfig
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool ClientConsistencyChecks { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool ServerConsistencyChecks { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public ChecksumGranularity ChecksumGranularity { get; set; }

        public EntityDebugConfig()
        {
        }
    }
}