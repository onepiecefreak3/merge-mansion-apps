using Metaplay.Core.Model;
using System.Collections.Generic;

namespace GameLogic.MiniEvents
{
    [MetaSerializable]
    public class MiniEventOverrideDictionary<T, U>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Dictionary<T, MiniEventOverrides<U>> Overrides { get; set; }

        public MiniEventOverrideDictionary()
        {
        }
    }
}