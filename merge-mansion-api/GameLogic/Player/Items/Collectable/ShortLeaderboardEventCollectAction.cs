using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(14)]
    public class ShortLeaderboardEventCollectAction : IProgressCollectAction, ICollectAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Progress { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool LevelUpMergeChain { get; set; }

        private ShortLeaderboardEventCollectAction()
        {
        }

        public ShortLeaderboardEventCollectAction(int progress, bool levelUpMergeChain)
        {
        }
    }
}