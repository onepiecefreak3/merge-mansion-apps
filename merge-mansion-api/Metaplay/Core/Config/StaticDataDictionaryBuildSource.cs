using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using System.Collections.Generic;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializableDerived(104)]
    [MetaFormHidden]
    [MetaAllowNoSerializedMembers]
    public class StaticDataDictionaryBuildSource : GameConfigBuildSource, IGameConfigSourceFetcher
    {
        private Dictionary<string, StaticSourceDataItem> _dataDict;
        public override string DisplayName { get; }

        private StaticDataDictionaryBuildSource()
        {
        }

        public StaticDataDictionaryBuildSource(IEnumerable<ValueTuple<string, object>> data)
        {
        }
    }
}