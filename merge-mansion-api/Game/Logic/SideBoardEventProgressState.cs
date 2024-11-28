using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;
using System.Collections.Generic;

namespace Game.Logic
{
    [MetaSerializable]
    public class SideBoardEventProgressState
    {
        [ExcludeFromGdprExport]
        [MetaMember(1, (MetaMemberFlags)0)]
        public SideBoardEventId SideBoardEventId { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(2, (MetaMemberFlags)0)]
        public SideBoardEventStateReport CurrentState { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public Dictionary<int, SideBoardEventStateReport> ReportByEventLevel { get; set; }

        public SideBoardEventProgressState()
        {
        }
    }
}