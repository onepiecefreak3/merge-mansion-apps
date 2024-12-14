using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents.SoloMilestone;
using System.Runtime.Serialization;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Events
{
    [MetaSerializableDerived(16)]
    [MetaActivableSet("SoloMilestoneEvent", false)]
    public class PlayerSoloMilestoneEventModel : MetaActivableSet<SoloMilestoneEventId, SoloMilestoneEventInfo, SoloMilestoneEventModel>
    {
        [IgnoreDataMember]
        public Action<SoloMilestoneMilestonesInfo> OnMilestoneReached;
        [IgnoreDataMember]
        public Action<int, int> OnTokenAdded;
        public PlayerSoloMilestoneEventModel()
        {
        }
    }
}