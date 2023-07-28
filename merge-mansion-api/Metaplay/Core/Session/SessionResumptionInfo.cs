using Metaplay.Core.Model;

namespace Metaplay.Core.Session
{
    [MetaSerializable]
    public class SessionResumptionInfo
    {
        [MetaMember(1, 0)]
        public SessionToken Token { get; set; } // 0x10
        [MetaMember(2, 0)]
        public SessionAcknowledgement Acknowledgement { get; set; } // 0x18

        public SessionResumptionInfo() { }

        public SessionResumptionInfo(SessionToken token, SessionAcknowledgement acknowledgement)
        {
            Token = token;
            Acknowledgement = acknowledgement;
        }

        public static SessionResumptionInfo FromParticipantState(SessionParticipantState state)
        {
            return new SessionResumptionInfo(state.Token, SessionAcknowledgement.FromParticipantState(state));
        }
    }
}
