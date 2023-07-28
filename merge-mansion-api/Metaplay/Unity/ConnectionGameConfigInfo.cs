using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Player;

namespace Metaplay.Unity
{
	public class ConnectionGameConfigInfo // TypeDefIndex: 13030
    {
        // Fields
        public readonly ContentHash BaselineVersion; // 0x10
        public readonly ContentHash PatchesVersion; // 0x20
        public readonly List<ExperimentVariantPair> ExperimentMemberships; // 0x30

        // Methods

        // RVA: 0x1D60F84 Offset: 0x1D60F84 VA: 0x1D60F84
        public ConnectionGameConfigInfo(ContentHash baselineVersion, ContentHash patchesVersion,
            List<ExperimentVariantPair> experimentMemberships)
        {
            BaselineVersion = baselineVersion;
            PatchesVersion = patchesVersion;
            ExperimentMemberships = experimentMemberships;
        }

        // RVA: 0x1D60FD4 Offset: 0x1D60FD4 VA: 0x1D60FD4
        //public IncidentGameConfigInfo ToIncidentInfo() { }
    }
}
