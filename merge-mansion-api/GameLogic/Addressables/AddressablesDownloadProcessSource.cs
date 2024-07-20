using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Addressables
{
    public class AddressablesDownloadProcessSource : IConfigItemSource<AddressablesDownloadProcess, AddressablesDownloadProcessId>, IGameConfigSourceItem<AddressablesDownloadProcessId, AddressablesDownloadProcess>, IHasGameConfigKey<AddressablesDownloadProcessId>
    {
        public AddressablesDownloadProcessId ConfigKey { get; set; }
        public List<string> DownloadProcessNames { get; set; }

        public AddressablesDownloadProcessSource()
        {
        }
    }
}