using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    public class PlayerLiveOpsEventsServerOnlyModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<MetaGuid, PlayerLiveOpsEventServerOnlyModel> EventModels { get; set; }

        public PlayerLiveOpsEventsServerOnlyModel()
        {
        }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime LastRefreshedAt { get; set; }
    }
}