using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Addressables
{
    [MetaSerializable]
    public class AddressablesDownloadProcess : IGameConfigData<AddressablesDownloadProcessId>, IGameConfigData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public AddressablesDownloadProcessId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<string> DownloadProcessNames { get; set; }

        public AddressablesDownloadProcess()
        {
        }

        public AddressablesDownloadProcess(AddressablesDownloadProcessId configKey, List<string> downloadProcessNames)
        {
        }
    }
}