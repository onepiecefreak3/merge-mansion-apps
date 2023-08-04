using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Network
{
    [MetaSerializable]
    public class SocketProbeStep
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsSuccess { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration Elapsed { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Error { get; set; }

        public SocketProbeStep()
        {
        }

        private SocketProbeStep(bool isSuccess, MetaDuration elapsed, string error)
        {
        }
    }
}