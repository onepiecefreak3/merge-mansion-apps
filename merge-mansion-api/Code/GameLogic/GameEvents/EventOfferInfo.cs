using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Config.Costs;
using Metaplay.GameLogic.Player.Rewards;
using Metaplay.Metaplay.Core.Activables;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
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
