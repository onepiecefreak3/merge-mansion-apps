using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class DebugBoardStatesInfo : IGameConfigData<DebugBoardStateId>, IGameConfigData, IHasGameConfigKey<DebugBoardStateId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DebugBoardStateId DebugBoardStateId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }
        public DebugBoardStateId ConfigKey { get; }

        public DebugBoardStatesInfo()
        {
        }

        public DebugBoardStatesInfo(DebugBoardStateId debugBoardStateId, List<PlayerReward> rewards)
        {
        }
    }
}