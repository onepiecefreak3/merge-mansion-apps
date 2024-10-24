using Metaplay.Core.Model;
using GameLogic.Player.Director.Config;
using GameLogic.CardCollection;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Hotspots.Actions
{
    [MetaSerializableDerived(17)]
    public class OpenWildCard : IDirectorAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private CardCollectionCardId WildCardId { get; set; }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }

        private OpenWildCard()
        {
        }

        public OpenWildCard(CardCollectionCardId wildCardId)
        {
        }
    }
}