using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core.Localization;

namespace GameLogic.Story.Videos
{
    public class VideoSource : IConfigItemSource<Video, VideoId>, IGameConfigSourceItem<VideoId, Video>, IHasGameConfigKey<VideoId>
    {
        public VideoId ConfigKey { get; set; }
        private string AssetRef { get; set; }
        private List<TranslationId> SubtitleText { get; set; }
        private List<int> SubtitleStartFrame { get; set; }
        private List<int> SubtitleEndFrame { get; set; }
        private List<string> CompleteAction { get; set; }
        private bool OverrideAudio { get; set; }
        private string MusicTrack { get; set; }

        public VideoSource()
        {
        }
    }
}