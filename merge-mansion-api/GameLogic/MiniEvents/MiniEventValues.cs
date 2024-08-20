using Metaplay.Core.Model;
using System;

namespace GameLogic.MiniEvents
{
    [MetaSerializable]
    public struct MiniEventValues<T>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public T[] OverrideValues { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string[] OverrideRows { get; set; }
    }
}