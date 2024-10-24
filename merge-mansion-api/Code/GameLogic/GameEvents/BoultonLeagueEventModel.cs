using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using GameLogic.Player.Rewards;
using System;
using Metaplay.Core;
using System.Runtime.Serialization;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(17)]
    public class BoultonLeagueEventModel : MetaActivableState<BoultonLeagueEventId, BoultonLeagueEventInfo>, IEventSharedInfo, IPointsEvent
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override BoultonLeagueEventId ActivableId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int StageNumber { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Score { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool StartNoted { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool EndNoted { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public EntityId DivisionId { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public bool LeaderboardPlacementRewardsClaimed { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool ForceUnlocked { get; set; }

        [IgnoreDataMember]
        public IStringId Id { get; }

        [IgnoreDataMember]
        public int Points { get; }
        public EventGroupId GroupId { get; }
        public string EventId { get; }
        public int Priority { get; }
        public string SharedEventId { get; }

        private BoultonLeagueEventModel()
        {
        }

        public BoultonLeagueEventModel(BoultonLeagueEventInfo eventInfo)
        {
        }
    }
}