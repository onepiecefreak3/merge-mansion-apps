using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerDevicePushNotifications
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string FirebaseMessagingToken;
        [IgnoreDataMember]
        public bool IsEmpty { get; }

        public PlayerDevicePushNotifications()
        {
        }
    }
}