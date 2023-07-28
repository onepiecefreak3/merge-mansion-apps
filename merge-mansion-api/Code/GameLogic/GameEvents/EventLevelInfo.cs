using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventLevelInfo : IGameConfigData<EventLevelId>
    {
        [MetaMember(1, 0)]
        public EventLevelId EventLevelId { get; set; }
        [MetaMember(2, 0)]
        public int RequiredPoints { get; set; }
        [MetaMember(3, 0)]
        public List<PlayerReward> Rewards { get; set; }

        public EventLevelId ConfigKey => EventLevelId;
    }
}
