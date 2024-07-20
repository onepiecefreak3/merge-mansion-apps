using Metaplay.Core.Model;
using GameLogic.Hotspots.CardStack;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(34)]
    public class CardStackRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private CardStackId CardStackId { get; set; }

        public CardStackId CardStack => CardStackId;

        public CardStackRequirement()
        {
        }

        public CardStackRequirement(CardStackId cardStackId)
        {
        }
    }
}