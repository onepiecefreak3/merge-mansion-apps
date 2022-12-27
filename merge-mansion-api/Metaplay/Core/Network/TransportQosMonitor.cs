using System.Collections.Generic;
using Metaplay.Metaplay.Client.Messages;

namespace Metaplay.Metaplay.Core.Network
{
    public class TransportQosMonitor
    {
        private bool _isWriteHealthy; // 0x10
        private bool _isReadHealthy; // 0x11
        private bool _isLoggedIn; // 0x12
        private bool _hasTransport; // 0x13

        public bool IsHealthy { get; set; } // 0x14

        public TransportQosMonitor()
        {
            Reset();
        }

        public void Reset()
        {
            IsHealthy = true;

            _isWriteHealthy = true;
            _isReadHealthy = true;
            _isLoggedIn = true;
            _hasTransport = false;
        }

        public bool ProcessMessages(List<MetaMessage> messages, bool isLoggedIn)
        {
            foreach (var message in messages)
            {
                if (message is MessageTransportInfoWrapperMessage mtiwm)
                    if (mtiwm.Info is StreamMessageTransport.ReadDurationWarningInfo rdwi)
                        _isReadHealthy = rdwi.IsEnd;
                    else if (mtiwm.Info is StreamMessageTransport.WriteDurationWarningInfo wdwi)
                        _isWriteHealthy = wdwi.IsEnd;
                    else if (mtiwm.Info is ServerConnection.TransportLifecycleInfo tlci)
                    {
                        _isWriteHealthy = true;
                        _isReadHealthy = true;
                        _hasTransport = tlci.IsTransportAttached;
                    }
            }

            var localHealthy = IsHealthy;

            _isLoggedIn = isLoggedIn;
            if (!_isWriteHealthy || !_isReadHealthy || !isLoggedIn)
                IsHealthy = false;
            else
                IsHealthy = _hasTransport;

            return localHealthy != IsHealthy;
        }
    }
}
