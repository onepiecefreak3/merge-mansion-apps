using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public struct GameConfigLibraryAliasTable<TKey>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<TKey, TKey> Values;
    }
}