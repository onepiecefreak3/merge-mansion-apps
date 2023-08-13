using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(5)]
    public class GarageCleanupEventModel : MetaActivableState<GarageCleanupEventId, GarageCleanupEventInfo>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override GarageCleanupEventId ActivableId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Level { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public GarageCleanupEventBoardModel BoardModel { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool LevelStarted { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool SpawnerItemClaimed { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public bool LevelBought { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public bool StartNoted { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool EndNoted { get; set; }

        [IgnoreDataMember]
        public override MetaActivableParams ActivableParams { get; }

        [IgnoreDataMember]
        public GarageCleanupEventInfo Info { get; }

        private GarageCleanupEventModel()
        {
        }

        public GarageCleanupEventModel(GarageCleanupEventInfo info)
        {
        }
    // STUB
    }
}