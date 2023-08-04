using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace GameLogic.Player.Items.Bubble
{
    [MetaSerializableDerived(1)]
    public class BubbleProgressionEventProgressBonus : IBubbleBonus
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventId EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Progress { get; set; }

        public BubbleProgressionEventProgressBonus()
        {
        }

        public BubbleProgressionEventProgressBonus(ProgressionEventId eventId, int progress)
        {
        }
    }
}