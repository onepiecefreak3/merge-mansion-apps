using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineLevelInfo : IGameConfigData<MysteryMachineLevelId>, IGameConfigData, IHasGameConfigKey<MysteryMachineLevelId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineLevelId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F64 Multiplier { get; set; }

        public MysteryMachineLevelInfo()
        {
        }

        public MysteryMachineLevelInfo(MysteryMachineLevelId configKey, F64 multiplier)
        {
        }
    }
}