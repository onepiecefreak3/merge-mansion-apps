using System;

namespace Metaplay.Metaplay.Core.Network
{
    public class SessionNonceService
    {
        private readonly uint _appLaunchId; // 0x10
        private uint _sessionConnectionIndex; // 0x14
        private uint _sessionNonce; // 0x18

        public SessionNonceService(Guid appLaunchId)
        {
            _appLaunchId = BitConverter.ToUInt32(appLaunchId.ToByteArray());
        }

        public void NewSession()
        {
            _sessionConnectionIndex = 0;
            _sessionNonce = BitConverter.ToUInt32(Guid.NewGuid().ToByteArray());
        }

        public void NewConnection()
        {
            _sessionConnectionIndex++;
        }

        public uint GetSessionConnectionIndex()
        {
            return _sessionConnectionIndex;
        }

        public uint GetSessionNonce()
        {
            return _sessionNonce;
        }

        public uint GetTransportAppLaunchId()
        {
            return _appLaunchId;
        }
    }
}
