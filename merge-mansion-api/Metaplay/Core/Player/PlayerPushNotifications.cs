using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerPushNotifications
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Dictionary<string, PlayerDevicePushNotifications> _devices;
        public PlayerPushNotifications()
        {
        }
    }
}