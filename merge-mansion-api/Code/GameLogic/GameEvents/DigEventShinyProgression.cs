using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventShinyProgression : IGameConfigData<DigEventShinyProgressionId>, IGameConfigData, IHasGameConfigKey<DigEventShinyProgressionId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DigEventShinyProgressionId ProgressionId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool RandomUndiscoveredItemMode { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<DigEventBoardId> ShinyBoards { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int GuaranteedInBoards { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public F32 A { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public F32 B { get; set; }

        public DigEventShinyProgressionId ConfigKey => ProgressionId;

        public DigEventShinyProgression()
        {
        }

        public DigEventShinyProgression(DigEventShinyProgressionId progressionId, bool randomUndiscoveredItemMode, List<DigEventBoardId> shinyBoards, int guaranteedInBoards, F32 a0, F32 b0)
        {
        }
    }
}