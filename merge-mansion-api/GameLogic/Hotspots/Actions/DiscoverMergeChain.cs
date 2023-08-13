using GameLogic.MergeChains;
using GameLogic.Player.Director.Config;
using Metaplay.Core.Model;

namespace GameLogic.Hotspots.Actions
{
    [MetaSerializableDerived(7)]
    public class DiscoverMergeChain : IDirectorAction
    {
        [MetaMember(1, 0)]
        private MergeChainId MergeChainId { get; set; }

        private DiscoverMergeChain()
        {
        }

        public DiscoverMergeChain(MergeChainId mergeChainId)
        {
        }
    }
}