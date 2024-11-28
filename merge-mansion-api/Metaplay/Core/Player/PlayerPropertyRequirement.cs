using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerPropertyRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerPropertyId Id { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerPropertyConstant Min { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public PlayerPropertyConstant Max { get; set; }

        private PlayerPropertyRequirement()
        {
        }

        public PlayerPropertyRequirement(PlayerPropertyId id, PlayerPropertyConstant min, PlayerPropertyConstant max)
        {
        }
    }
}