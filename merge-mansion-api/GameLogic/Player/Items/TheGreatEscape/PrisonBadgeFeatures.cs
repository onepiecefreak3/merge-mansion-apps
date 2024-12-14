using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Merge;

namespace GameLogic.Player.Items.TheGreatEscape
{
    [MetaSerializable]
    public class PrisonBadgeFeatures
    {
        public static PrisonBadgeFeatures NoBadgeFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsBadge { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int CellItem { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public PrisonerType Prisoner { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<int> PrisonerLetters { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public PlayerReward BadgeReward { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MergeBoardId TargetBoardId { get; set; }

        private PrisonBadgeFeatures()
        {
        }

        public PrisonBadgeFeatures(bool isBadge, int cellItem, PrisonerType prisoner, List<int> prisonerLetters, PlayerReward reward, MergeBoardId targetBoardId)
        {
        }
    }
}