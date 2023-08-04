using System.Collections.Generic;
using System;

namespace Metaplay.Core.Config
{
    public class GameConfigPatch
    {
        private Dictionary<string, GameConfigEntryPatch> _entryPatches;
        public Type ConfigType { get; set; }
        public bool IsEmpty { get; }

        public GameConfigPatch(Type configType, Dictionary<string, GameConfigEntryPatch> entryPatches)
        {
        }
    }
}