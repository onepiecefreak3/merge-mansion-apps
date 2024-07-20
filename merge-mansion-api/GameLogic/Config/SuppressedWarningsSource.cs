using Code.GameLogic.Config;
using System;
using Metaplay.Core.Config;

namespace GameLogic.Config
{
    public class SuppressedWarningsSource : IConfigItemSource<SuppressedBuildLogsInfo, int>, IGameConfigSourceItem<int, SuppressedBuildLogsInfo>, IHasGameConfigKey<int>
    {
        private int RuleId { get; set; }
        private string Sheet { get; set; }
        private string RowN { get; set; }
        private string ColumnN { get; set; }
        private string Code { get; set; }
        public int ConfigKey { get; }

        public SuppressedWarningsSource()
        {
        }
    }
}