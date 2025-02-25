using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    public class DigEventShinyProgressionSource : IConfigItemSource<DigEventShinyProgression, DigEventShinyProgressionId>, IGameConfigSourceItem<DigEventShinyProgressionId, DigEventShinyProgression>, IHasGameConfigKey<DigEventShinyProgressionId>
    {
        public DigEventShinyProgressionId ConfigKey { get; set; }
        public bool RandomUndiscoveredItemMode { get; set; }
        public List<DigEventBoardId> ShinyBoards { get; set; }
        public int GuaranteedInBoards { get; set; }
        public F32 A { get; set; }
        public F32 B { get; set; }

        public DigEventShinyProgressionSource()
        {
        }
    }
}