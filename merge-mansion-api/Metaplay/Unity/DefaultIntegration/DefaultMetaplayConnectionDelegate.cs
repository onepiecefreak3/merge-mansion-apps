using System;
using Metaplay.Core;
using Metaplay.Core.Client;
using Metaplay.Core.Message;
using Metaplay.Core.Player;

namespace Metaplay.Unity.DefaultIntegration
{
    public class DefaultMetaplayConnectionDelegate : IMetaplayClientConnectionDelegate
    {
        // 0x10
        //protected ISessionStartHook SessionStartHook { get; set; }
        // 0x18
        public ISessionContextProvider SessionContext { get; set; }

        public Handshake.ILoginRequestGamePayload GetLoginPayload()
        {
            return null;
        }

        public SessionProtocol.ISessionStartRequestGamePayload GetSessionStartRequestPayload()
        {
            return null;
        }

        public virtual void OnSessionStarted(ClientSessionStartResources startResources)
        {
            throw new NotImplementedException();
        }

        public void Init()
        { }

        public void Update()
        { }

        public void OnHandshakeComplete()
        { }

        public LoginDebugDiagnostics GetLoginDebugDiagnostics(bool isSessionResumption)
        {
            var now = MetaTime.Now;

            IPlayerClientContext playerContext = null;
            if (isSessionResumption)
                playerContext = SessionContext?.PlayerContext;

            MetaDuration? currentPauseDelta = null;
            MetaDuration? pauseEndDelta = null;
            if (MetaplaySDK.ApplicationPauseStatus == ApplicationPauseStatus.Pausing)
                currentPauseDelta = now - MetaplaySDK.ApplicationLastPauseBeganAt;
            else
            {
                if (MetaplaySDK.ApplicationPauseStatus == ApplicationPauseStatus.Running)
                {
                    if (MetaplaySDK.ApplicationLastPauseBeganAt != MetaTime.Epoch)
                        pauseEndDelta = now - (MetaplaySDK.ApplicationLastPauseBeganAt + MetaplaySDK.ApplicationLastPauseDuration);
                }
            }

            var lastUpdateTime = playerContext?.LastUpdateTimeDebug;

            MetaDuration? playerContextUpdateDuration = null;
            if (lastUpdateTime.HasValue)
                playerContextUpdateDuration = now - lastUpdateTime.GetValueOrDefault();

            return new LoginDebugDiagnostics
            {
                Timestamp = now,
                Session = MetaplaySDK.Connection.TryGetLoginSessionDebugDiagnostics(),
                ServerConnection = MetaplaySDK.Connection.TryGetLoginServerConnectionDebugDiagnostics(),
                Transport = MetaplaySDK.Connection.TryGetLoginTransportDebugDiagnostics(),
                IncidentReport = MetaplaySDK.IncidentUploader.GetLoginIncidentReportDebugDiagnostics(),
                CurrentPauseDuration = currentPauseDelta,
                DurationSincePauseEnd = pauseEndDelta,
                DurationSinceConnectionUpdate = now - MetaplaySDK.ApplicationPreviousEndOfTheFrameAt,
                DurationSincePlayerContextUpdate = playerContextUpdateDuration,
                ExpectSessionResumptionPing = true
            };
        }

        public void OnFullProtocolHashMismatch(uint clientProtocolHash, uint serverProtocolHash)
        { }

        public void FlushPendingMessages()
        {
            throw new NotImplementedException();
        }

        public virtual SocialAuthenticationClaimBase GetSocialAuthLoginCredentials()
        {
            return null;
        }
    }
}
