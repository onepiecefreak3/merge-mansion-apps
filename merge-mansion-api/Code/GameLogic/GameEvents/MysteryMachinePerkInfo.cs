using Metaplay.Core.Model;
using Metaplay.Core.Config;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachinePerkInfo : IGameConfigData<MysteryMachinePerkId>, IGameConfigData, IHasGameConfigKey<MysteryMachinePerkId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachinePerkId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public IMysteryMachinePerk Perk { get; set; }

        public MysteryMachinePerkInfo()
        {
        }

        public MysteryMachinePerkInfo(MysteryMachinePerkId configKey, IMysteryMachinePerk perk)
        {
        }
    }
}