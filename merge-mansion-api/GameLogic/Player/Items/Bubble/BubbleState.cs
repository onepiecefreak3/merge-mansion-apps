using Metaplay.Core.Model;
using Metaplay.Core;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Bubble
{
    [MetaSerializable]
    public class BubbleState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime BubbleEndTime { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Obsolete("Bonuses should be used instead")]
        public IBubbleBonus Bonus { get; set; }

        public BubbleState()
        {
        }

        public BubbleState(MetaTime endTime, IBubbleBonus bonus)
        {
        }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<IBubbleBonus> Bonuses { get; set; }

        public BubbleState(MetaTime endTime, List<IBubbleBonus> bonuses)
        {
        }
    }
}