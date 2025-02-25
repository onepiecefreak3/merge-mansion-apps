using Metaplay.Core.Model;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventMuseumShelfModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DigEventMuseumShelfInfo ShelfInfo { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<ValueTuple<DigEventItemId, bool>> Slots { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private MuseumShelfRewardState RewardState { get; set; }

        [IgnoreDataMember]
        public DigEventMuseumShelfId ShelfId { get; }

        public DigEventMuseumShelfModel()
        {
        }

        public DigEventMuseumShelfModel(DigEventMuseumShelfInfo shelfInfo)
        {
        }
    }
}