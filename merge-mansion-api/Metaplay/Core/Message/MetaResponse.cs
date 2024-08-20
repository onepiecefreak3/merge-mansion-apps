using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [RequestResponse]
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    [MetaSerializable]
    public abstract class MetaResponse
    {
        protected MetaResponse()
        {
        }
    }
}