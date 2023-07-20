using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Session
{
    [MetaSerializable]
    public class SessionAcknowledgement
    {
        [MetaMember(1, 0)]
        public int NumReceived { get; set; } // 0x10
        [MetaMember(2, 0)]
        public uint ChecksumForReceived { get; set; } // 0x14

        public SessionAcknowledgement() { }

        public SessionAcknowledgement(int numReceived, uint checksumForReceived)
        {
            NumReceived = numReceived;
            ChecksumForReceived = checksumForReceived;
        }

        public static SessionAcknowledgement FromParticipantState(SessionParticipantState state)
        {
            return new SessionAcknowledgement(state.NumReceived, state.ChecksumForReceived);
        }
    }
}
