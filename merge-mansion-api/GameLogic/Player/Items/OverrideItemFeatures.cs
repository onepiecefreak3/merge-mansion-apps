using Metaplay.Core.Model;
using Metaplay.Core;
using System;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    public class OverrideItemFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaDuration? TimeContainerInitialTime { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int? ChargesInitialCharges { get; set; }

        public OverrideItemFeatures()
        {
        }

        public OverrideItemFeatures(MetaDuration? timeContainerInitialTime, int? chargesInitialCharges)
        {
        }
    }
}