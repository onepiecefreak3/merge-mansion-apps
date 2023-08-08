using Metaplay.Core.Model;
using Metaplay.Core;
using System;
using Metaplay.Core.Serialization;
using Metaplay.Core.Player;
using System.Collections.Generic;
using Metaplay.Core.MultiplayerEntity;
using Metaplay.Core.Client;

namespace Metaplay.Unity
{
    [MetaSerializable]
    public class DefaultPersistedOfflineState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime PersistedAt { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int PlayerSchemaVersion { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaSerialized<IPlayerModelBase> PlayerModel { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<DefaultPersistedOfflineState.PersistedEntityState> Entities { get; set; }

        private DefaultPersistedOfflineState()
        {
        }

        public DefaultPersistedOfflineState(MetaTime persistedAt, int playerSchemaVersion, MetaSerialized<IPlayerModelBase> playerModel, List<DefaultPersistedOfflineState.PersistedEntityState> entities)
        {
        }

        [MetaSerializable]
        public struct PersistedEntityState
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public MetaSerialized<IMultiplayerModel> Model { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public ClientSlot Slot { get; set; }

            [MetaMember(3, (MetaMemberFlags)0)]
            public EntityId? MemberId { get; set; }
        }
    }
}