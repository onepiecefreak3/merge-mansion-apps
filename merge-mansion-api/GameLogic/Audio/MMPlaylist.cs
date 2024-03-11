using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using System.Collections.Generic;

namespace GameLogic.Audio
{
    [MetaSerializable]
    public class MMPlaylist : IGameConfigData<string>, IGameConfigData, IHasGameConfigKey<string>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string PlaylistName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaRef<MMTrack> ThemeTrack { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<MetaRef<MMTrack>> Tracks { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool Shuffle { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public bool Dynamic { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public bool Enabled { get; set; }

        public MMPlaylist()
        {
        }

        public MMPlaylist(string configKey, string playlistName, MetaRef<MMTrack> themeTrack, List<MetaRef<MMTrack>> tracks, bool shuffle, bool dynamic, bool enabled)
        {
        }
    }
}