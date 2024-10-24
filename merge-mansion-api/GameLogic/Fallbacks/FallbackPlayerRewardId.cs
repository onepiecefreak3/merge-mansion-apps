using Metaplay.Core.Model;
using Metaplay.Core;
using System;

namespace GameLogic.Fallbacks
{
    [MetaSerializable]
    public class FallbackPlayerRewardId : StringId<FallbackPlayerRewardId>
    {
        public static FallbackPlayerRewardId None;
        public static string Prefix;
        public FallbackPlayerRewardId()
        {
        }
    }
}