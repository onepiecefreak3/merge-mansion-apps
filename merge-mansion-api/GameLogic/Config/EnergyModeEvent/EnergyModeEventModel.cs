using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System;

namespace GameLogic.Config.EnergyModeEvent
{
    [MetaSerializableDerived(13)]
    public class EnergyModeEventModel : MetaActivableState<EnergyModeEventId, EnergyModeEventInfo>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override EnergyModeEventId ActivableId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private byte BoolFields { get; set; }
        public bool StartNoted { get; set; }
        public bool EndNoted { get; set; }
        public bool FtueNoted { get; set; }

        private EnergyModeEventModel()
        {
        }

        public EnergyModeEventModel(EnergyModeEventInfo info)
        {
        }
    }
}