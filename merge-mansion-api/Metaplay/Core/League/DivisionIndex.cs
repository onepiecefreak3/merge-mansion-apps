using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.League
{
    [LeaguesEnabledCondition]
    [MetaSerializable]
    public struct DivisionIndex
    {
        private static int DivisionBits;
        private static int RankBits;
        private static int LeagueBits;
        private static int SeasonBits;
        public static ulong DivisionMax;
        public static ulong RankMax;
        public static ulong LeagueMax;
        public static ulong SeasonMax;
        private static ulong DivisionMask;
        private static ulong RankMask;
        private static int RankShift;
        private static ulong LeagueMask;
        private static int LeagueShift;
        private static ulong SeasonMask;
        private static int SeasonShift;
        [MetaMember(1, (MetaMemberFlags)0)]
        public int League;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Season;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int Rank;
        [MetaMember(4, (MetaMemberFlags)0)]
        public int Division;
    }
}