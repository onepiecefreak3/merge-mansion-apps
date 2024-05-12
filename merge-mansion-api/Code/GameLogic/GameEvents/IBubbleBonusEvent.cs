using Metaplay.Core.Math;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public interface IBubbleBonusEvent
    {
        F32? BubbleBonusDivisor { get; }

        List<BubbleBonusInfo> SecondaryBoardBubbleBonus { get; }
    }
}