using Metaplay.Core.Model;

namespace Metaplay.Core
{
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    [MetaSerializable]
    public abstract class MetaMessage
    {
        protected MetaMessage()
        {
        }
    }
}