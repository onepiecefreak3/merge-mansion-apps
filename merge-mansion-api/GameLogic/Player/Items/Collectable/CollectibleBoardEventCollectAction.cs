using Code.GameLogic.GameEvents;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(7)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class CollectibleBoardEventCollectAction : IProgressCollectAction, ICollectAction
    {
        [MetaMember(2, 0)]
        public int Progress { get; set; }

        [MetaMember(3, 0)]
        public bool LevelUpMergeChain { get; set; }

        private CollectibleBoardEventCollectAction()
        {
        }

        public CollectibleBoardEventCollectAction(CollectibleBoardEventId collectibleBoardEventId, int progress, bool levelUpMergeChain)
        {
        }

        public CollectibleBoardEventCollectAction(int progress, bool levelUpMergeChain)
        {
        }
    }
}