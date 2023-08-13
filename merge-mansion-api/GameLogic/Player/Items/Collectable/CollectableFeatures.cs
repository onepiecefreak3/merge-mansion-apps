using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializable]
    public class CollectableFeatures
    {
        [MetaMember(1)]
        public bool Collectable { get; set; }

        [MetaMember(2)]
        public ICollectAction CollectAction { get; set; }

        [MetaMember(3)]
        public string OverrideSfx { get; set; }

        [MetaMember(4)]
        public bool ConfirmCollectBelowMergeChainLevel { get; set; }

        public static CollectableFeatures NoCollectable;
        private CollectableFeatures()
        {
        }

        public CollectableFeatures(ICollectAction collectAction, string overrideSfx, bool confirmCollectBelowMergeChainLevel)
        {
        }
    }
}