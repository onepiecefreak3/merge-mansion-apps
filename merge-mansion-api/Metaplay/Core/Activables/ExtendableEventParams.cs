using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Activables
{
    [MetaSerializable]
    public class ExtendableEventParams
    {
        [MetaMember(1, 0)]
        public int MaxExtensionsPerActivation; // 0x10
        [MetaMember(2, 0)]
        public MetaDuration ExtensionDuration; // 0x18
        [MetaMember(3, 0)]
        public MetaDuration ExtensionReviewDuration; // 0x20
        public ExtendableEventParams()
        {
        }

        public ExtendableEventParams(int maxExtensionsPerActivation, MetaDuration extensionDuration, MetaDuration extensionReviewDuration)
        {
        }
    }
}