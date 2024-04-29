using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineLevelSource : IConfigItemSource<MysteryMachineLevelInfo, MysteryMachineLevelId>, IGameConfigSourceItem<MysteryMachineLevelId, MysteryMachineLevelInfo>, IHasGameConfigKey<MysteryMachineLevelId>
    {
        public MysteryMachineLevelId ConfigKey { get; set; }
        private F64 Multiplier { get; set; }

        public MysteryMachineLevelSource()
        {
        }
    }
}