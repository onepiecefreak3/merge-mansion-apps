using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableSet("MysteryMachineEvent", false)]
    [MetaSerializableDerived(11)]
    public class PlayerMysteryMachineEventsModel : MetaActivableSet<MysteryMachineEventId, MysteryMachineEventInfo, MysteryMachineEventModel>
    {
        public PlayerMysteryMachineEventsModel()
        {
        }
    }
}