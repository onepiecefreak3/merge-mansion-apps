using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    [RequestResponse]
    public abstract class MetaRequest
    {
        protected MetaRequest()
        {
        }
    }
}