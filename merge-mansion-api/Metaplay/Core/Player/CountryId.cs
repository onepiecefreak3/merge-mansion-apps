using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public struct CountryId
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string IsoCode { get; set; }
    }
}