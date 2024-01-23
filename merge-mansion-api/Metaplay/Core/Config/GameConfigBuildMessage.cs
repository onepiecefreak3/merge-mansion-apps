using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public class GameConfigBuildMessage
    {
        private GameConfigBuildMessage()
        {
        }

        public GameConfigBuildMessage(string sheetName, string configKey, string message, string columnHint, string variant, string url, string sourcePath, string sourceMember, int sourceLineNumber, GameConfigBuildMessageLevel messageLevel, AdditionalMessageData additionalMessageData)
        {
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        public string SourceInfo;
        [MetaMember(6, (MetaMemberFlags)0)]
        public string ShortSource;
        [MetaMember(2, (MetaMemberFlags)0)]
        public string SourceLocation;
        [MetaMember(3, (MetaMemberFlags)0)]
        public string LocationUrl;
        [MetaMember(4, (MetaMemberFlags)0)]
        public string ItemId;
        [MetaMember(5, (MetaMemberFlags)0)]
        public string VariantId;
        [MetaMember(10, (MetaMemberFlags)0)]
        public GameConfigLogLevel Level;
        [MetaMember(11, (MetaMemberFlags)0)]
        public string Message;
        [MetaMember(12, (MetaMemberFlags)0)]
        public string Exception;
        [MetaMember(20, (MetaMemberFlags)0)]
        public string CallerFileName;
        [MetaMember(21, (MetaMemberFlags)0)]
        public string CallerMemberName;
        [MetaMember(22, (MetaMemberFlags)0)]
        public int CallerLineNumber;
        public GameConfigBuildMessage(string sourceInfo, string shortSource, string sourceLocation, string locationUrl, string itemId, string variantId, GameConfigLogLevel level, string message, string exception, string callerFileName, string callerMemberName, int callerLineNumber)
        {
        }
    }
}