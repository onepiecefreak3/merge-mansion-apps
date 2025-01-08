using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(12)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class MysteryMachineEventProgressCollectAction : IProgressCollectAction, ICollectAction
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Progress { get; set; }

        private MysteryMachineEventProgressCollectAction()
        {
        }

        public MysteryMachineEventProgressCollectAction(int progress)
        {
        }
    }
}