using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializableDerived(12)]
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