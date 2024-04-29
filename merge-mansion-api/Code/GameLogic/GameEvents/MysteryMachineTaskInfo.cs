using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.Player.Rewards;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineTaskInfo : IGameConfigData<MysteryMachineTaskId>, IGameConfigData, IHasGameConfigKey<MysteryMachineTaskId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineTaskId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public IMysteryMachineTask Task { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public PlayerReward Reward { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool Recurring { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int RecurringIncrease { get; set; }

        public MysteryMachineTaskInfo()
        {
        }

        public MysteryMachineTaskInfo(MysteryMachineTaskId configKey, IMysteryMachineTask task, PlayerReward reward, bool recurring, int recurringIncrease)
        {
        }
    }
}