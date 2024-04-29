using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace Game.Cloud.Webshop
{
    [MetaSerializable]
    public class WebShopSettings : GameConfigKeyValue<WebShopSettings>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DefaultURLOnSignIn { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool IsEnabledNotificationRedirect { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool IsEnabledOverwriteNotificationURLOnSignIn { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool IsEnabledOverwriteSecureCodePopupURLOnSignIn { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool IsEnabledSecureCodePopupRedirect { get; set; }

        public WebShopSettings()
        {
        }
    }
}