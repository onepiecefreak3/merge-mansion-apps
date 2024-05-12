using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public struct PlayerLocation
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CountryId Country { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ContinentCodeMaybe { get; set; }
    }
}