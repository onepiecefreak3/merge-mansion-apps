using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineItemScore : IGameConfigData<MysteryMachineItemScoreId>, IGameConfigData, IHasGameConfigKey<MysteryMachineItemScoreId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineItemScoreId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Score { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int Multiplier { get; set; }

        public MysteryMachineItemScore()
        {
        }

        public MysteryMachineItemScore(MysteryMachineItemScoreId configKey, string item, int score, int multiplier)
        {
        }
    }
}