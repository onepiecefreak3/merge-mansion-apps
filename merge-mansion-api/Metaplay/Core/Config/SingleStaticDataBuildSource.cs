using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Config
{
    [MetaAllowNoSerializedMembers]
    [MetaSerializableDerived(103)]
    [MetaFormHidden]
    public class SingleStaticDataBuildSource : GameConfigBuildSource, IGameConfigSourceFetcher
    {
        private StaticSourceDataItem _data;
        public override string DisplayName { get; }

        private SingleStaticDataBuildSource()
        {
        }

        public SingleStaticDataBuildSource(object data)
        {
        }
    }
}