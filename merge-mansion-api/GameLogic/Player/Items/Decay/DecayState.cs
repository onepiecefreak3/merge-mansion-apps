using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Decay
{
    [MetaSerializable]
    public class DecayState
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        private MetaDuration relativeTimeSpendOnDecay;
        [MetaMember(4, (MetaMemberFlags)0)]
        private MetaTime lastTimeAddTime;
        [MetaMember(1, 0)]
        public MetaTime EstimatedTime { get; set; }

        [MetaMember(2, 0)]
        public MetaTime StartTime { get; set; }

        public DecayState()
        {
        }

        public DecayState(DecayState existingState)
        {
        }

        public DecayState(MetaTime startTimeInMilliseconds)
        {
        }
    }
}