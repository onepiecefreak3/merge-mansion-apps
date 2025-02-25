using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public struct RewardSourceContext
    {
        public static RewardSourceContext MakeYourOwnOffer { get; }
        public static RewardSourceContext BigBundleOffer { get; }
        public static RewardSourceContext GenericOffer { get; }
        public static RewardSourceContext None { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsOffer { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string SourceId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int LevelNumber { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int PlayerLevel { get; set; }
        public bool IsValid { get; }
    }
}