using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public class GameConfigMetaData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ContentHash ParentConfigHash { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public GameConfigBuildParameters BuildParams { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string BuildDescription { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaGuid ParentConfigId { get; set; }

        [MetaMember(100, (MetaMemberFlags)0)]
        public GameConfigBuildLog BuildLog { get; set; }
        public GameConfigBuildSummary BuildSummary { get; set; }

        public GameConfigMetaData()
        {
        }

        public GameConfigMetaData(MetaGuid parentConfigId, ContentHash parentConfigHash, GameConfigBuildParameters buildParams, GameConfigBuildLog buildLog, string buildDescription)
        {
        }
    }
}