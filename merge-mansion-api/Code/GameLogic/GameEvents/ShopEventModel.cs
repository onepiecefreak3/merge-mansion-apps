using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System;
using System.Runtime.Serialization;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(3)]
    [MetaBlockedMembers(new int[] { 3, 8, 9, 10, 11 })]
    public class ShopEventModel : ExtendableEventState<EventId, ShopEventInfo>, IEventGroupModel<ShopEventInfo>
    {
        [MetaMember(4, (MetaMemberFlags)0)]
        public int Level;
        [MetaMember(5, (MetaMemberFlags)0)]
        public int Points;
        [MetaMember(6, (MetaMemberFlags)0)]
        public int LastSeenPoints;
        [MetaMember(7, (MetaMemberFlags)0)]
        public int LastSeenLevel;
        [MetaMember(12, (MetaMemberFlags)0)]
        public bool CanBeResolved;
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override EventId ActivableId { get; set; }

        [IgnoreDataMember]
        public override MetaActivableParams ActivableParams { get; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerEventOfferModel EventOffers { get; set; }

        [IgnoreDataMember]
        public ShopEventInfo Info { get; }

        [IgnoreDataMember]
        public override ExtendableEventParams ExtendableEventParams { get; }

        private ShopEventModel()
        {
        }

        public ShopEventModel(ShopEventInfo info)
        {
        }
    }
}