using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventMuseumCollectionModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<DigEventMuseumShelfId, DigEventMuseumShelfModel> MuseumShelves { get; set; }

        public DigEventMuseumCollectionModel()
        {
        }

        public DigEventMuseumCollectionModel(List<DigEventMuseumShelfInfo> shelfInfos)
        {
        }
    }
}