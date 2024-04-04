using Metaplay.Core.Model;
using GameLogic.Hotspots.CardStack;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(35)]
    public class CardStackVisibleRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private CardStackId CardStackId { get; set; }

        private CardStackVisibleRequirement()
        {
        }

        public CardStackVisibleRequirement(CardStackId cardStackId)
        {
        }
    }
}