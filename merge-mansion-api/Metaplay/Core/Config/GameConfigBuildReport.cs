using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public class GameConfigBuildReport
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GameConfigBuildMessageLevel HighestMessageLevel { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<GameConfigBuildMessage> ValidationMessages { get; set; }

        public GameConfigBuildReport(List<GameConfigValidationResult> validationResults)
        {
        }

        private GameConfigBuildReport()
        {
        }
    }
}