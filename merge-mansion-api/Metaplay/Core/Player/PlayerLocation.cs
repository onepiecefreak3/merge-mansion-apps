using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public struct PlayerLocation
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CountryId Country { get; set; }
    }
}