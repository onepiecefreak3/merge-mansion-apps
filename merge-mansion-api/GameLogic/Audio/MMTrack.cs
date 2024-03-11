using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;

namespace GameLogic.Audio
{
    [MetaSerializable]
    public class MMTrack : IGameConfigData<string>, IGameConfigData, IHasGameConfigKey<string>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string TrackName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaDuration TrackLength { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool Enabled { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool Locked { get; set; }

        public MMTrack()
        {
        }

        public MMTrack(string configKey, string trackName, MetaDuration trackLength, bool enabled, bool locked)
        {
        }
    }
}