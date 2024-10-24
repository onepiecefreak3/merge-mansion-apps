using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class EnergySettings
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public long MaxRechargeAmount { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration? UnitRestoreDuration { get; set; }

        public EnergySettings()
        {
        }

        public EnergySettings(long maxRechargeAmount, MetaDuration? unitRestoreDuration)
        {
        }
    }
}