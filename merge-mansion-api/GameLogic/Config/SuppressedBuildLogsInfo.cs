using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Data;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class SuppressedBuildLogsInfo : IGameConfigData<int>, IGameConfigData, IHasGameConfigKey<int>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int RuleId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Library { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Row { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string Column { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public BuildLogCode BuildLogCode { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public GameConfigLogLevel BuildLogLevel { get; set; }
        public int ConfigKey => RuleId;

        public SuppressedBuildLogsInfo()
        {
        }

        public SuppressedBuildLogsInfo(int ruleId, BuildLogLevel logLevel, string library, string row, string column, BuildLogCode code)
        {
        }

        public SuppressedBuildLogsInfo(int ruleId, GameConfigBuildMessageLevel logLevel, string library, string row, string column, BuildLogCode code)
        {
        }

        public SuppressedBuildLogsInfo(int ruleId, GameConfigLogLevel logLevel, string library, string row, string column, BuildLogCode code)
        {
        }
    }
}