using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public interface ILevelEventModel
    {
        ILevelEventInfo LevelEventInfo { get; }

        int Level { get; set; }

        int LevelProgress { get; set; }

        List<LevelEventClaimedLevelData> ClaimedLevels { get; }
    }
}