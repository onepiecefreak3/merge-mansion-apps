using Metaplay.Core.Config;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [MetaReservedMembers(100, 200)]
    [MetaSerializable]
    public abstract class PlayerSegmentInfoBase : IGameConfigData<PlayerSegmentId>, IGameConfigData, IHasGameConfigKey<PlayerSegmentId>
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public PlayerSegmentId SegmentId { get; set; }

        [MetaMember(103)]
        public PlayerCondition PlayerCondition { get; set; }

        [MetaMember(102)]
        public string DisplayName { get; set; }

        [MetaMember(101)]
        public string Description { get; set; }
        public PlayerSegmentId ConfigKey => SegmentId;

        public PlayerSegmentInfoBase()
        {
        }

        public PlayerSegmentInfoBase(PlayerSegmentId segmentId, PlayerCondition playerCondition, string displayName, string description)
        {
        }
    }
}