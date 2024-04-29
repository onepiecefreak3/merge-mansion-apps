using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineItemScoreSource : IConfigItemSource<MysteryMachineItemScore, MysteryMachineItemScoreId>, IGameConfigSourceItem<MysteryMachineItemScoreId, MysteryMachineItemScore>, IHasGameConfigKey<MysteryMachineItemScoreId>
    {
        public MysteryMachineItemScoreId ConfigKey { get; set; }
        private string ItemType { get; set; }
        private string ItemId { get; set; }
        private int Score { get; set; }
        private int Multiplier { get; set; }

        public MysteryMachineItemScoreSource()
        {
        }
    }
}