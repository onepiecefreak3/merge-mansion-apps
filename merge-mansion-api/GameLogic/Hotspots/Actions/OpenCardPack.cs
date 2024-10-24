using Metaplay.Core.Model;
using GameLogic.Player.Director.Config;
using GameLogic.CardCollection;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Hotspots.Actions
{
    [MetaSerializableDerived(16)]
    public class OpenCardPack : IDirectorAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private CardCollectionPackId CardCollectionPackId { get; set; }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }

        private OpenCardPack()
        {
        }

        public OpenCardPack(CardCollectionPackId cardCollectionPackId)
        {
        }
    }
}