using Metaplay.Core.Model;
using System;

namespace Game.Logic
{
    [MetaSerializable]
    public class SideBoardEventStateReport
    {
        [ExcludeFromGdprExport]
        [MetaMember(1, (MetaMemberFlags)0)]
        public int SinkedResourceItemCount { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public int CompletedTasksCount { get; set; }

        public SideBoardEventStateReport()
        {
        }
    }
}