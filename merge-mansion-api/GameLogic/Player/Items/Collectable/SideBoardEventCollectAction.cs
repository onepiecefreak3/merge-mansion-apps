using Metaplay.Core.Model;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(11)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class SideBoardEventCollectAction : IProgressCollectAction, ICollectAction
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Progress { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool LevelUpMergeChain { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public SideBoardEventId SideBoardEventId { get; set; }

        private SideBoardEventCollectAction()
        {
        }

        public SideBoardEventCollectAction(int progress, bool levelUpMergeChain, SideBoardEventId sideBoardEventId)
        {
        }
    }
}