using Metaplay.Core.Model;

namespace Metaplay.Core
{
    [MetaSerializable]
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    public abstract class MetaMessage
    {
        protected MetaMessage()
        {
        }
    }
}