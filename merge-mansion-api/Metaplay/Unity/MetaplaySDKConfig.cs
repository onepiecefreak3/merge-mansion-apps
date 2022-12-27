using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Message;

namespace Metaplay.Metaplay.Unity
{
	public struct MetaplaySDKConfig // TypeDefIndex: 13022
    {
        // Fields
        //public LogLevel DefaultLogLevel; // 0x0
        //public Dictionary<string, LogLevel> LogLevelOverrides; // 0x8
        public BuildVersion BuildVersion; // 0x10
        public bool AutoCreateMetaplaySDKBehavior; // 0x28
        public ServerEndpoint ServerEndpoint; // 0x30
        public ConnectionConfig ConnectionConfig; // 0x38
        public MetaplayOfflineOptions OfflineOptions; // 0x40
        public IMetaplayConnectionDelegate ConnectionDelegate; // 0x48
        public IMetaplayLocalizationDelegate LocalizationDelegate; // 0x50
        public IMetaplayClientSocialAuthenticationDelegate SocialAuthenticationDelegate; // 0x58
        public ISessionContextProvider SessionContext; // 0x60
        public Action ExitRequestedCallback; // 0x68
    }
}
