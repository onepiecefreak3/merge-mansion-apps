using Code.GameLogic.GameEvents;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(8)]
    public class LeaderboardEventCollectAction : IProgressCollectAction, ICollectAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<LeaderboardEventInfo> LeaderboardEventRef { get; set; }

        [MetaMember(2, 0)]
        public int Progress { get; set; }
        public LeaderboardEventInfo LeaderboardEvent { get; }

        private LeaderboardEventCollectAction()
        {
        }

        public LeaderboardEventCollectAction(LeaderboardEventId leaderboardEventId, int progress)
        {
        }
    }
}