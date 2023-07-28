using Metaplay.Core;
using Metaplay.Core.Client;
using Metaplay.Core.Message;

namespace Metaplay.Unity
{
	public interface IMetaplayConnectionDelegate
    {
        // Methods

        // RVA: -1 Offset: -1 Slot: 0
        Handshake.ILoginRequestGamePayload GetLoginPayload();

        // RVA: -1 Offset: -1 Slot: 1
        SessionProtocol.ISessionStartRequestGamePayload GetSessionStartRequestPayload();

        // RVA: -1 Offset: -1 Slot: 2
        void OnSessionStarted(ClientSessionStartResources startResources);

        // RVA: -1 Offset: -1 Slot: 3
        void Init();

        // RVA: -1 Offset: -1 Slot: 4
        void Update();

        // RVA: -1 Offset: -1 Slot: 5
        void OnHandshakeComplete();

        // RVA: -1 Offset: -1 Slot: 6
        LoginDebugDiagnostics GetLoginDebugDiagnostics(bool isSessionResumption);

        // RVA: -1 Offset: -1 Slot: 7
        void OnFullProtocolHashMismatch(uint clientProtocolHash, uint serverProtocolHash);

        // RVA: -1 Offset: -1 Slot: 8
        void FlushPendingMessages();

        // RVA: -1 Offset: -1 Slot: 9
        SocialAuthenticationClaimBase GetSocialAuthLoginCredentials();
    }
}
