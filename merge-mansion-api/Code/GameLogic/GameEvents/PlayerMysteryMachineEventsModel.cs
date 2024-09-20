using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(11)]
    [MetaActivableSet("MysteryMachineEvent", false)]
    public class PlayerMysteryMachineEventsModel : MetaActivableSet<MysteryMachineEventId, MysteryMachineEventInfo, MysteryMachineEventModel>
    {
        public PlayerMysteryMachineEventsModel()
        {
        }
    }
}