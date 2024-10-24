using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    [MetaSerializable]
    [RequestResponse]
    public abstract class MetaResponse
    {
        protected MetaResponse()
        {
        }
    }
}