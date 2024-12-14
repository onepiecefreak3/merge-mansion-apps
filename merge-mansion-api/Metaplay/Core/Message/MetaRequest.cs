using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    [RequestResponse]
    [MetaSerializable]
    public abstract class MetaRequest
    {
        protected MetaRequest()
        {
        }
    }
}