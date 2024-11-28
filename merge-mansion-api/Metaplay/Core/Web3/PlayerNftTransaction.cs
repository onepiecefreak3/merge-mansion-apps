using Metaplay.Core.Model;
using System.Collections.Generic;

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

        public abstract IEnumerable<NftKey> TargetNfts { get; }

        protected PlayerNftTransaction()
        {
        }
    }
}