using System;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    public class GameConfigSourceMapping
    {
        static string BaselineVariantKey;
        public GameConfigSourceInfo SourceInfo;
        private Dictionary<string, GameConfigSourceLocation> _memberToSource;
        private Dictionary<ValueTuple<string, string>, GameConfigSourceLocation> _itemToSource;
        private GameConfigSourceMapping(GameConfigSourceInfo sourceInfo, Dictionary<string, GameConfigSourceLocation> memberToSource, Dictionary<ValueTuple<string, string>, GameConfigSourceLocation> itemToSource)
        {
        }
    }
}