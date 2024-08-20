using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using Code.GameLogic.GameEvents.SoloMilestone;
using Code.GameLogic;
using Code.GameLogic.GameEvents;
using System.Runtime.Serialization;
using System;
using Metaplay.Core.Math;
using Metaplay.Core.Player;

namespace GameLogic.Player.Events
{
    [MetaSerializableDerived(16)]
    public class SoloMilestoneEventModel : MetaActivableState<SoloMilestoneEventId, SoloMilestoneEventInfo>, IEnergyAttachmentEvent, IItemActivationEvent, IHotspotCompletionEvent
    {
        [IgnoreDataMember]
        public int InitialMilestoneNumber;
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override SoloMilestoneEventId ActivableId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private byte BoolFields { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int EventInstance { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int CurrentMilestone { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public SoloMilestoneEventState CurrentMilestoneState { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int Seed { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public ValueTuple<int, int, F32, int, int> LastSpawnedTokenInfo { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public PlayerSegmentId LastSpawnedTokenSegment { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public int AccumulativeProgress { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public int Progress { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public int LatestTokenReceived { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public SoloMilestoneCompletionState CompletionState { get; set; }
        public bool PreviewNoted { get; set; }
        public bool StartNoted { get; set; }
        public bool EndNoted { get; set; }

        [IgnoreDataMember]
        public EnergyType EnergyType { get; }

        [IgnoreDataMember]
        public int LastMilestoneForLastTokenReceived { get; set; }

        private SoloMilestoneEventModel()
        {
        }

        public SoloMilestoneEventModel(SoloMilestoneEventInfo info)
        {
        }
    }
}