using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Player.Items.Bubble
{
    [MetaSerializable]
    public class BubbleState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime BubbleEndTime { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public IBubbleBonus Bonus { get; set; }

        public BubbleState()
        {
        }

        public BubbleState(MetaTime endTime, IBubbleBonus bonus)
        {
        }
    }
}