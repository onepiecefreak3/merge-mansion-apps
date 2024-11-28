using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [RequestResponse]
    [MetaSerializable]
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    public abstract class MetaResponse
    {
        protected MetaResponse()
        {
        }
    }
}