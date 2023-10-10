using System.Collections.Generic;
using System;
using Metaplay.Core.Player;

namespace Metaplay.Core.Config
{
    public class ConfigPatchIdSet
    {
        private List<ConfigPatchIndex> _presentPatchIndexes;
        private bool[] _patchIsPresent;
        public int Count { get; }

        public ConfigPatchIdSet(HashSet<ExperimentVariantPair> presentPatchIds, Dictionary<ExperimentVariantPair, ConfigPatchIndex> allPatchIndexes)
        {
        }
    }
}