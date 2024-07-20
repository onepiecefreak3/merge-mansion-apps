using GameLogic.MergeChains;
using GameLogic.Player.Director.Config;
using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Hotspots.Actions
{
    [MetaSerializableDerived(7)]
    public class DiscoverMergeChain : IDirectorAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MergeChainId MergeChainId { get; set; }

        private DiscoverMergeChain()
        {
        }

        public DiscoverMergeChain(MergeChainId mergeChainId)
        {
        }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }
    }
}