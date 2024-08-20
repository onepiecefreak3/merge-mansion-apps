using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace GameLogic.MiniEvents
{
    [MetaSerializable]
    public class MiniEventOverrides<T>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<ValueTuple<MiniEventId, T>> Overrides { get; set; }

        public MiniEventOverrides()
        {
        }

        public MiniEventOverrides(ValueTuple<MiniEventId, T> initialElement)
        {
        }
    }
}