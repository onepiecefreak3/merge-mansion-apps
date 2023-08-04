using Metaplay.Core.Model;

namespace Metaplay.Core.Network
{
    [MetaSerializable]
    public class HttpRequestProbeResult
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public HttpRequestProbeStatus Status { get; set; }

        public HttpRequestProbeResult()
        {
        }
    }
}