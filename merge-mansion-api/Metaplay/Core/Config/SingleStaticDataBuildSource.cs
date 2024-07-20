using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializableDerived(103)]
    [MetaAllowNoSerializedMembers]
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