using Metaplay.Core.Activables;
using Metaplay.Core.Model;

namespace GameLogic.Config.EnergyModeEvent
{
    [MetaActivableSet("EnergyModeEvent", false)]
    [MetaSerializableDerived(12)]
    public class PlayerEnergyModeEventsModel : MetaActivableSet<EnergyModeEventId, EnergyModeEventInfo, EnergyModeEventModel>
    {
        public PlayerEnergyModeEventsModel()
        {
        }
    }
}