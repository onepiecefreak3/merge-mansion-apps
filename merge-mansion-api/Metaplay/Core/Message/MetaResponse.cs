using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
    [RequestResponse]
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    public abstract class MetaResponse
    {
        protected MetaResponse()
        {
        }
    }
}