using Metaplay.Core.Model;
using System.Collections.Generic;

namespace GameLogic.Hotspots.CardStack
{
    [MetaSerializable]
    public class CardStack
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardStackId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<PlayCard> Cards { get; set; }

        public CardStack()
        {
        }

        public CardStack(CardStackId id, List<PlayCard> cards)
        {
        }

        [MetaMember(3, (MetaMemberFlags)0)]
        public GroupingStyle Style { get; set; }

        public CardStack(CardStackId id, List<PlayCard> cards, GroupingStyle style)
        {
        }
    }
}