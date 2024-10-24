using Metaplay.Core.Model;
using System.Collections.Generic;
using GameLogic.CardCollection;
using GameLogic.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EvidenceRoomState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Dictionary<CardCollectionEvidenceBoxId, EvidenceBoxPurchaseState> EvidenceBoxStates { get; set; }

        public EvidenceRoomState()
        {
        }

        public EvidenceRoomState(TemporaryCardCollectionEventModel eventModel, PlayerModel playerModel)
        {
        }
    }
}