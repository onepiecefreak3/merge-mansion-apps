using Code.GameLogic.Config;
using System;
using Metaplay.Core.Config;
using Metaplay.Core;

namespace GameLogic.Audio
{
    public class MMTrackSource : IConfigItemSource<MMTrack, string>, IGameConfigSourceItem<string, MMTrack>, IHasGameConfigKey<string>
    {
        public string ConfigKey { get; set; }
        public string TrackName { get; set; }
        public MetaDuration TrackLength { get; set; }
        public bool Enabled { get; set; }
        public bool Locked { get; set; }

        public MMTrackSource()
        {
        }
    }
}