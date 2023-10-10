using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public class GameConfigBuildMessage
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string SheetName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ConfigKey { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Message { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string ColumnHint { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<string> Variants { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string Url { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string SourcePath { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public string SourceMember { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public int SourceLineNumber { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public GameConfigBuildMessageLevel MessageLevel { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public int Count { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public AdditionalMessageData AdditionalData { get; set; }

        private GameConfigBuildMessage()
        {
        }

        public GameConfigBuildMessage(string sheetName, string configKey, string message, string columnHint, string variant, string url, string sourcePath, string sourceMember, int sourceLineNumber, GameConfigBuildMessageLevel messageLevel, AdditionalMessageData additionalMessageData)
        {
        }
    }
}