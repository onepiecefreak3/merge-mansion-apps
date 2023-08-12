using Metaplay.Core.Model;
using GameLogic.MergeChains;

namespace GameLogic.Player.Items.Sinkable
{
    [MetaSerializableDerived(1)]
    public class LevelUpMergeChainSinkInAction : ISinkInAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MergeChainId MergeChainId { get; set; }

        public LevelUpMergeChainSinkInAction()
        {
        }

        public LevelUpMergeChainSinkInAction(MergeChainId mergeChainId)
        {
        }
    }
}