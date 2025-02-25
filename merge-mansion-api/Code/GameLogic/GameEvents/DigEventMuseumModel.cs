using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventMuseumModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<DigEventId, DigEventMuseumCollectionModel> OpenCollections { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool CollectionRewardClaimed { get; set; }

        public DigEventMuseumModel()
        {
        }
    }
}