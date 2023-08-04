using Metaplay.Core.Model;

namespace Metaplay.Core.Web3
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class PlayerNftTransaction
    {
        [MetaSerializable]
        public abstract class ContextBase
        {
            protected ContextBase()
            {
            }
        }
    }
}