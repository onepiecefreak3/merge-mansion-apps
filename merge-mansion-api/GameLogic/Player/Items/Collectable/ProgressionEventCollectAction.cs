using Code.GameLogic.GameEvents;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(6)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class ProgressionEventCollectAction : IProgressCollectAction, ICollectAction
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Progress { get; set; }

        private ProgressionEventCollectAction()
        {
        }

        public ProgressionEventCollectAction(ProgressionEventId progressionEventId, int progress)
        {
        }

        public ProgressionEventCollectAction(int progress)
        {
        }
    }
}