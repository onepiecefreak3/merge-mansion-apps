using Metaplay.Core.Activables;
using Metaplay.Core.Model;

namespace GameLogic.Config.EnergyModeEvent
{
    [MetaSerializableDerived(12)]
    [MetaActivableSet("EnergyModeEvent", false)]
    public class PlayerEnergyModeEventsModel : MetaActivableSet<EnergyModeEventId, EnergyModeEventInfo, EnergyModeEventModel>
    {
        public PlayerEnergyModeEventsModel()
        {
        }
    }
}