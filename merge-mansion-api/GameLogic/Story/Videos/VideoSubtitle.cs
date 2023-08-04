using Metaplay.Core.Model;
using Metaplay.Core.Localization;
using System;

namespace GameLogic.Story.Videos
{
    [MetaSerializable]
    public class VideoSubtitle
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public TranslationId Text { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int StartFrame { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int EndFrame { get; set; }

        private VideoSubtitle()
        {
        }

        public VideoSubtitle(TranslationId text, int startFrame, int endFrame)
        {
        }
    }
}