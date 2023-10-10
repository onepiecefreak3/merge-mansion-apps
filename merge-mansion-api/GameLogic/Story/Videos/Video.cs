using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Director.Config;

namespace GameLogic.Story.Videos
{
    [MetaSerializable]
    public class Video : IGameConfigData<VideoId>, IGameConfigData, IGameConfigKey<VideoId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public VideoId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string AssetRef { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<VideoSubtitle> VideoSubtitles { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private List<IDirectorAction> CompleteActions { get; set; }
        public IEnumerable<VideoSubtitle> Subtitles { get; }
        public IEnumerable<IDirectorAction> OnComplete { get; }

        public Video()
        {
        }

        public Video(VideoId configKey, string assetRef, IEnumerable<VideoSubtitle> videoSubtitles, IEnumerable<IDirectorAction> completeActions)
        {
        }
    }
}