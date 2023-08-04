using Code.GameLogic.GameEvents;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(6)]
    [MetaSerializable]
    public class ProgressionEventCollectAction : IProgressCollectAction, ICollectAction
    {
        [MetaMember(1)]
        private MetaRef<ProgressionEventInfo> ProgressionEventRef { get; set; }

        [MetaMember(2)]
        public int Progress { get; set; }
        public ProgressionEventInfo ProgressionEvent { get; }

        private ProgressionEventCollectAction()
        {
        }

        public ProgressionEventCollectAction(ProgressionEventId progressionEventId, int progress)
        {
        }
    }
}