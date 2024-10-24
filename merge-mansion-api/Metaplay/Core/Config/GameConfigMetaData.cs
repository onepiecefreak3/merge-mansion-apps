using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 100 })]
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
        public GameConfigBuildSummary BuildSummary { get; set; }

        public GameConfigMetaData()
        {
        }

        public GameConfigMetaData(MetaGuid parentConfigId, ContentHash parentConfigHash, GameConfigBuildParameters buildParams, GameConfigBuildLog buildLog, string buildDescription)
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        public GameConfigBuildReport BuildReport { get; set; }

        public GameConfigMetaData(MetaGuid parentConfigId, ContentHash parentConfigHash, GameConfigBuildParameters buildParams, GameConfigBuildReport buildReport, string buildDescription)
        {
        }

        public static int MaxReportMessages;
        [MetaMember(6, (MetaMemberFlags)0)]
        public Dictionary<string, GameConfigBuildSourceMetadata> BuildSourceMetadata;
        public GameConfigMetaData(MetaGuid parentConfigId, ContentHash parentConfigHash, GameConfigBuildParameters buildParams, GameConfigBuildReport buildReport, Dictionary<string, GameConfigBuildSourceMetadata> buildSourceMetadata, string buildDescription)
        {
        }

        private GameConfigMetaData(MetaGuid parentConfigId, ContentHash parentConfigHash, GameConfigBuildParameters buildParams, GameConfigBuildReport buildReport, string buildDescription, GameConfigBuildSummary buildSummary)
        {
        }
    }
}