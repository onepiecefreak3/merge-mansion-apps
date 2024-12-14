using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace GameLogic.Player
{
    [Obsolete("Replaced by AuxEnergyState. Required for migration.")]
    [MetaSerializable]
    public class SecondaryEnergyState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public long Amount { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime? NextRestoreTime { get; set; }

        public SecondaryEnergyState()
        {
        }
    }
}