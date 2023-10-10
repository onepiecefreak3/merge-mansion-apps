using System;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    public class GameConfigBuildDebugInfo
    {
        static string BaselineVariantKey;
        public SpreadsheetDebugInfo SpreadsheetDebugInfo;
        private Dictionary<string, int> _variantKeyToRowLUT;
        private Dictionary<string, int> _headerKeyToColumnLUT;
        public GameConfigBuildDebugInfo(SpreadsheetDebugInfo spreadsheetDebugInfo)
        {
        }
    }
}