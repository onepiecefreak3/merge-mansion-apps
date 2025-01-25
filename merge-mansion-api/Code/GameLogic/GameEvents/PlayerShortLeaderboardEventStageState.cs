using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Player.Board;
using System.Collections.Generic;
using GameLogic.Player.Items;
using System;
using GameLogic.Config.Costs;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class PlayerShortLeaderboardEventStageState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ShortLeaderboardEventStageState State { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public EntityId? DivisionId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaTime? RequestJoinTime { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaTime? StartTime { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MergeBoard MergeBoard { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<IBoardItem> PocketItems { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public int EnterMergeBoardCount { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        private byte BoolFields { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public int Points { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public int Stars { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public int Level { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public int LevelProgress { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public HashSet<int> ClaimedLevels { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public int ReplayCostStep { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public MetaTime? ReplayCostCooldownStartTime { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public GameCurrencyCost RequestJoinCost { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public int ReplayCount { get; set; }
        public bool Completed { get; set; }
        public bool EnterBoardDialogueTriggered { get; set; }
        public bool CompletionRewardsClaimed { get; set; }
        public bool CompletionDialogueTriggered { get; set; }
        public bool StarsClaimed { get; set; }
        public bool StarsClaimNoted { get; set; }

        public PlayerShortLeaderboardEventStageState()
        {
        }
    }
}