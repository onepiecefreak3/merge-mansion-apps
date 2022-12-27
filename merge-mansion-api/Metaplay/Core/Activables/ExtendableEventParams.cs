using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Activables
{
    public class ExtendableEventParams
    {
        [MetaMember(1, 0)]
        public int MaxExtensionsPerActivation; // 0x10
        [MetaMember(2, 0)]
        public MetaDuration ExtensionDuration; // 0x18
        [MetaMember(3, 0)]
        public MetaDuration ExtensionReviewDuration; // 0x20
	}
}
