using Code.GameLogic.Config;
using System;
using Metaplay.Core.Config;

namespace GameLogic.Audio
{
    public class MMPlaylistSource : IConfigItemSource<MMPlaylist, string>, IGameConfigSourceItem<string, MMPlaylist>, IHasGameConfigKey<string>
    {
        public string ConfigKey { get; set; }
        public string PlaylistName { get; set; }
        public string ThemeTrack { get; set; }
        public string Tracks { get; set; }
        public bool Shuffle { get; set; }
        public bool Dynamic { get; set; }
        public bool Enabled { get; set; }

        public MMPlaylistSource()
        {
        }
    }
}