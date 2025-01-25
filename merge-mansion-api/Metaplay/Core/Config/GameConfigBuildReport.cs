using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public class GameConfigBuildReport
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GameConfigLogLevel HighestMessageLevel { get; set; }

        [MaxCollectionSize(2147483647)]
        [MetaMember(2, (MetaMemberFlags)0)]
        public GameConfigValidationMessage[] ValidationMessages { get; set; }

        public GameConfigBuildReport(List<GameConfigValidationResult> validationResults)
        {
        }

        private GameConfigBuildReport()
        {
        }

        [MetaMember(3, (MetaMemberFlags)0)]
        [MaxCollectionSize(2147483647)]
        public GameConfigBuildMessage[] BuildMessages { get; set; }

        public GameConfigBuildReport(IEnumerable<GameConfigBuildMessage> buildMessages, List<GameConfigValidationResult> validationResults)
        {
        }

        private GameConfigBuildReport(GameConfigLogLevel highestMessageLevel, GameConfigBuildMessage[] buildMessages, GameConfigValidationMessage[] validationMessages)
        {
        }
    }
}