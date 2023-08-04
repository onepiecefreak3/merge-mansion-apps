using Metaplay.Core.Model;
using System.Collections.Generic;
using Metaplay.Core.Player;

namespace Metaplay.Core.Debugging
{
    [MetaSerializable]
    public class IncidentGameConfigInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ContentHash SharedConfigBaselineVersion;
        [MetaMember(2, (MetaMemberFlags)0)]
        public ContentHash SharedConfigPatchesVersion;
        [MetaMember(3, (MetaMemberFlags)0)]
        public List<ExperimentVariantPair> ExperimentMemberships;
        private IncidentGameConfigInfo()
        {
        }

        public IncidentGameConfigInfo(ContentHash sharedConfigBaselineVersion, ContentHash sharedConfigPatchesVersion, List<ExperimentVariantPair> experimentMemberships)
        {
        }
    }
}