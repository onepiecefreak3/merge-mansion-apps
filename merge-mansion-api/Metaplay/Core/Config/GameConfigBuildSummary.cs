using System;
using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public struct GameConfigBuildSummary
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<GameConfigLogLevel, int> BuildMessagesCount { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public Dictionary<GameConfigLogLevel, int> ValidationMessagesCount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public GameConfigLogLevel HighestMessageLevel { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool IsBuildMessagesTrimmed { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool IsValidationMessagesTrimmed { get; set; }

        public GameConfigBuildSummary()
        {
        }

        private GameConfigBuildSummary(Dictionary<GameConfigLogLevel, int> buildMessagesCount, Dictionary<GameConfigLogLevel, int> validationMessagesCount, GameConfigLogLevel highestMessageLevel, bool isBuildMessagesTrimmed, bool isValidationMessagesTrimmed)
        {
        }
    }
}