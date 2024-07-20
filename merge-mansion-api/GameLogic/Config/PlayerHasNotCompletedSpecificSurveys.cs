using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1045)]
    public class PlayerHasNotCompletedSpecificSurveys : TypedPlayerPropertyId<bool>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int[] BroadcastIds;
        public override string DisplayName { get; }

        public PlayerHasNotCompletedSpecificSurveys(string broadcastIds)
        {
        }

        private PlayerHasNotCompletedSpecificSurveys()
        {
        }
    }
}