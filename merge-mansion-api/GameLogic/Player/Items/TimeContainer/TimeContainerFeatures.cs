using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.TimeContainer
{
    [MetaSerializable]
    public class TimeContainerFeatures
    {
        [MetaMember(1, 0)]
        public bool StoresTime { get; set; }

        [MetaMember(2, 0)]
        public MetaDuration DefaultInitialTime { get; set; }

        [MetaMember(3, 0)]
        public TimeContainerMergeBehavior MergeBehavior { get; set; }

        public static TimeContainerFeatures NoContainer;
        public TimeContainerFeatures()
        {
        }
    }
}