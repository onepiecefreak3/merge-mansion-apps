using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaBlockedMembers(new int[] { 3 })]
    [MetaSerializable]
    public class CollectableFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool Collectable { get; set; }

        [MetaMember(2)]
        public ICollectAction CollectAction { get; set; }

        [MetaMember(4)]
        public bool ConfirmCollectBelowMergeChainLevel { get; set; }

        public static CollectableFeatures NoCollectable;
        private CollectableFeatures()
        {
        }

        public CollectableFeatures(ICollectAction collectAction, string overrideSfx, bool confirmCollectBelowMergeChainLevel)
        {
        }

        public CollectableFeatures(ICollectAction collectAction, bool confirmCollectBelowMergeChainLevel)
        {
        }
    }
}