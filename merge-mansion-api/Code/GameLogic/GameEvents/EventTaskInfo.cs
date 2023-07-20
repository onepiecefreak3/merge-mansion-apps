using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Player.Requirements;
using Metaplay.GameLogic.Player.Rewards;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventTaskInfo: IGameConfigData<EventTaskId>
    {
        [MetaMember(1, 0)]
        public EventTaskId EventTaskId { get; set; }
        [MetaMember(2, 0)]
        public string DisplayName { get; set; }
        [MetaMember(3, 0)]
        public string Description { get; set; }
        [MetaMember(4, 0)]
        public List<PlayerReward> Rewards { get; set; }
        [MetaMember(5, 0)]
        public List<PlayerItemRequirement> Requirements { get; set; }
        [MetaMember(6, 0)]
        public List<MetaRef<EventTaskInfo>> UnlockTaskRefs { get; set; }
        [MetaMember(7, 0)]
        public string TaskTitleLocId { get; set; }

        public EventTaskId ConfigKey => EventTaskId;
    }
}
