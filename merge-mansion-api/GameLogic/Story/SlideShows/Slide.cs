using Metaplay.Core.Model;
using Metaplay.Core;
using Metaplay.Core.Localization;
using System;

namespace GameLogic.Story.SlideShows
{
    [MetaSerializable]
    public class Slide
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaDuration Duration { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public TranslationId Text { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string AssetRef { get; set; }

        private Slide()
        {
        }

        public Slide(MetaDuration duration, TranslationId text, string assetRef)
        {
        }
    }
}