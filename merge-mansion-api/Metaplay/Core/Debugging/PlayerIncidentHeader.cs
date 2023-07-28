using Metaplay.Core.Model;

namespace Metaplay.Core.Debugging
{
    [MetaSerializable]
    public class PlayerIncidentHeader
    {
        [MetaMember(1, 0)]
        public string IncidentId { get; set; }
        [MetaMember(2, 0)]
        public EntityId PlayerId { get; set; }
        [MetaMember(3, 0)]
        public string Fingerprint { get; set; }
        [MetaMember(4, 0)]
        public string Type { get; set; }
        [MetaMember(5, 0)]
        public string SubType { get; set; }
        [MetaMember(6, 0)]
        public string Reason { get; set; }
        [MetaMember(7, 0)]
        public MetaTime OccurredAt { get; set; }
	}
}
