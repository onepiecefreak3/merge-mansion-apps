using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Network
{
    [MetaSerializable]
    public class GameServerEndpointResult
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Hostname;
        [MetaMember(3, (MetaMemberFlags)0)]
        public Dictionary<int, SocketProbeResult> Gateways;
        public GameServerEndpointResult()
        {
        }

        public GameServerEndpointResult(string hostname, List<int> ports)
        {
        }
    }
}