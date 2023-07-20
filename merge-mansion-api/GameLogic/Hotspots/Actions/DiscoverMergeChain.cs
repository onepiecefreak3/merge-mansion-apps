using Metaplay.GameLogic.MergeChains;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Hotspots.Actions
{
    [MetaSerializableDerived(7)]
    [MetaSerializable]
    public class DiscoverMergeChain : IDirectorAction
    {
        [MetaMember(1, 0)]
        private MergeChainId MergeChainId { get; set; }
    }
}
