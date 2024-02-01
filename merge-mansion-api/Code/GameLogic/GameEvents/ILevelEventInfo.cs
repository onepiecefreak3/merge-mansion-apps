using Metaplay.Core;
using System.Collections.Generic;
using System;

namespace Code.GameLogic.GameEvents
{
    public interface ILevelEventInfo
    {
        IStringId LevelEventId { get; }

        List<MetaRef<EventLevelInfo>> LevelRefs { get; }

        Dictionary<MetaRef<EventLevelInfo>, MetaRef<EventLevelInfo>> FallbackLevelRefs { get; }

        List<MetaRef<EventLevelInfo>> RecurringLevelRefs { get; }

        List<int> ProgressionPopupHeaderImageLevels { get; }
    }
}