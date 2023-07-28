using System.Collections.Generic;
using GameLogic.Config.Costs;
using GameLogic.Player.Rewards;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventOfferInfo: IGameConfigData<EventOfferId>
    {
        [MetaMember(1, 0)]
        public EventOfferId EventOfferId { get; set; }
        [MetaMember(2, 0)]
        public string DisplayName { get; set; }
        [MetaMember(3, 0)]
        public string Description { get; set; }
        [MetaMember(5, 0)]
        public ICost Cost { get; set; }
        [MetaMember(4, 0)]
        public List<PlayerReward> Rewards { get; set; }
        [MetaMember(6, 0)]
        public MetaActivableParams ActivableParams { get; set; }

        public EventOfferId ConfigKey => EventOfferId;
    }
}
