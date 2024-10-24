using Metaplay.Core.League.Player;
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Leaderboard.BoultonLeague
{
    [PlayerLeaguesEnabledCondition]
    [MetaSerializable]
    [MetaSerializableDerived(151)]
    public class BoultonLeagueDivisionAvatar : PlayerDivisionAvatarBase, IMetacoreLeagueAvatar
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        public Dictionary<int, int> FinishedCountPerStageNumber;
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [ServerOnly]
        public string AssociationId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int StageNumber { get; set; }

        private BoultonLeagueDivisionAvatar()
        {
        }

        public BoultonLeagueDivisionAvatar(string displayName, string associationId, Dictionary<int, int> finishedCountPerStageNumber, int stageNumber)
        {
        }
    }
}