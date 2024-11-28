using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Hotspots.CardStack
{
    [MetaSerializable]
    public class CardStackInfo : IGameConfigData<CardStackId>, IGameConfigData, IHasGameConfigKey<CardStackId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardStackId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<PlayCard> Cards { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Width { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int Height { get; set; }

        public CardStackInfo()
        {
        }

        public CardStackInfo(CardStackId id, List<ValueTuple<int, int>> cards, int width, int height)
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        public GroupingStyle Style { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string Theme { get; set; }

        public CardStackInfo(CardStackId id, List<ValueTuple<int, int, int>> cards, int width, int height, GroupingStyle style, string theme)
        {
        }
    }
}