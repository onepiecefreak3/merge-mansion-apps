using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Merge;
using System;

namespace GameLogic
{
    [MetaSerializable]
    public class TimedMergeBoardLiveConfig : IGameConfigData<MergeBoardId>, IGameConfigData, IGameConfigKey<MergeBoardId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MergeBoardId MergeBoardId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool IsEnabled { get; set; }
        public MergeBoardId ConfigKey { get; }

        public TimedMergeBoardLiveConfig()
        {
        }
    }
}