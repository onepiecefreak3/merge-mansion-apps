using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Player.Items.TimeContainer
{
    [MetaSerializable]
    public class TimeContainerState
    {
        private static TimeContainerState empty;
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaDuration Remaining { get; set; }

        public TimeContainerState()
        {
        }
    }
}