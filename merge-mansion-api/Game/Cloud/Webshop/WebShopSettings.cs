using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Math;

namespace Game.Cloud.Webshop
{
    [MetaBlockedMembers(new int[] { 3, 4 })]
    [MetaSerializable]
    public class WebShopSettings : GameConfigKeyValue<WebShopSettings>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DefaultURLOnSignIn { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool IsEnabledNotificationRedirect { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool IsEnabledSecureCodePopupRedirect { get; set; }

        public WebShopSettings()
        {
        }

        [MetaMember(6, (MetaMemberFlags)0)]
        public WebShopLinkType SignInLinkTypeOnNotification { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public WebShopLinkType SignInLinkTypeOnSecureCodePopup { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public F32 RedirectDelay { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public F32 NoRedirectDelay { get; set; }
    }
}