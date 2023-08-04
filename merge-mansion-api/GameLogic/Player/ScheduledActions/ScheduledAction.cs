using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System.Runtime.Serialization;

namespace GameLogic.Player.ScheduledActions
{
    [MetaSerializable]
    public class ScheduledAction : MetaActivableState<ScheduledActionId, ScheduledActionInfo>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override ScheduledActionId ActivableId { get; set; }

        [IgnoreDataMember]
        public ScheduledActionInfo Info { get; }

        public ScheduledAction()
        {
        }

        public ScheduledAction(ScheduledActionInfo info)
        {
        }
    }
}