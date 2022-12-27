using System;
using System.Collections.Generic;
using Metaplay.Metaplay.Client.Messages;
using Metaplay.Metaplay.Core.Debugging;
using Metaplay.Metaplay.Core.Message;

namespace Metaplay.Metaplay.Unity
{
    public class PlayerIncidentUploader
    {
        private const float UploadCooldownSeconds = 10;

        private PlayerIncidentRepository _repository; // 0x10
        private PlayerIncidentTracker _tracker; // 0x18
        private bool _isConnected; // 0x20
        private List<string> _requestedIncidentIds; // 0x28
        private bool _isUploading; // 0x30
        private float _nextUploadCountdown; // 0x34
        private object _pendingIncidentsLock; // 0x38
        private List<PlayerIncidentHeader> _pendingIncidentHeaders; // 0x40
        private LoginIncidentReportDebugDiagnostics _debugDiagnostics; // 0x48

        public PlayerIncidentUploader(PlayerIncidentRepository repository, PlayerIncidentTracker tracker, List<PlayerIncidentHeader> initialPendingIncidentHeaders)
        {
            _nextUploadCountdown = 10f;
            _pendingIncidentsLock = new object();
            _debugDiagnostics = new LoginIncidentReportDebugDiagnostics();
            _repository = repository;
            _tracker = tracker;
            _pendingIncidentHeaders = initialPendingIncidentHeaders ?? throw new ArgumentNullException(nameof(initialPendingIncidentHeaders));

            MetaplaySDK.MessageDispatcher.AddListener<ConnectedToServer>(OnConnectedToServer);
            MetaplaySDK.MessageDispatcher.AddListener<DisconnectedFromServer>(OnDisconnectedFromServer);
            MetaplaySDK.MessageDispatcher.AddListener<PlayerRequestIncidentReportUploads>(OnPlayerRequestIncidentReportUploads);
            MetaplaySDK.MessageDispatcher.AddListener<PlayerAckIncidentReportUpload>(OnPlayerAckIncidentReportUpload);

            _tracker.OnNewIncidentReport += OnNewIncidentReport;
        }

        public LoginIncidentReportDebugDiagnostics GetLoginIncidentReportDebugDiagnostics()
        {
            return _debugDiagnostics.Clone();
        }

        private void OnNewIncidentReport(PlayerIncidentReport report)
        {
            throw new NotImplementedException();
        }

        private void OnConnectedToServer(ConnectedToServer _)
        {
            throw new NotImplementedException();
        }

        private void OnDisconnectedFromServer(DisconnectedFromServer _)
        {
            throw new NotImplementedException();
        }

        private void OnPlayerRequestIncidentReportUploads(PlayerRequestIncidentReportUploads request)
        {
            throw new NotImplementedException();
        }

        private void OnPlayerAckIncidentReportUpload(PlayerAckIncidentReportUpload ackUpload)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            MetaplaySDK.MessageDispatcher.RemoveListener<ConnectedToServer>(OnConnectedToServer);
            MetaplaySDK.MessageDispatcher.RemoveListener<DisconnectedFromServer>(OnDisconnectedFromServer);
            MetaplaySDK.MessageDispatcher.RemoveListener<PlayerRequestIncidentReportUploads>(OnPlayerRequestIncidentReportUploads);
            MetaplaySDK.MessageDispatcher.RemoveListener<PlayerAckIncidentReportUpload>(OnPlayerAckIncidentReportUpload);

            if (_tracker == null)
                return;

            _tracker.OnNewIncidentReport -= OnNewIncidentReport;
        }
    }
}
