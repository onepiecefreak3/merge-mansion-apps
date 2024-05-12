using Metaplay.Core.Model;
using GameLogic.Player;
using Metaplay.Core.Math;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class BubbleBonusInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EnergyType DivisorEnergyType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F32 DivisorOverride { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool DivisorEnabled { get; set; }

        public BubbleBonusInfo()
        {
        }

        public BubbleBonusInfo(EnergyType divisorEnergyType, F32 divisorOverride, bool divisorEnabled)
        {
        }
    }
}