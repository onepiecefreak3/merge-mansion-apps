using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.TimeContainer
{
    [MetaSerializable]
    public class TimeContainerFeatures : ITimeContainerFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool StoresTime { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration DefaultInitialTime { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public TimeContainerMergeBehavior MergeBehavior { get; set; }

        public static TimeContainerFeatures NoContainer;
        public TimeContainerFeatures()
        {
        }
    }
}