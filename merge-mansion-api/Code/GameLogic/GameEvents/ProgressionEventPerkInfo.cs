using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Code.GameLogic.Config;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ProgressionEventPerkInfo : IGameConfigData<ProgressionEventPerkId>, IGameConfigData, IHasGameConfigKey<ProgressionEventPerkId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventPerkId Id { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ProgressionEventPerk Perk { get; set; }
        public ProgressionEventPerkId ConfigKey => Id;

        public ProgressionEventPerkInfo()
        {
        }

        public ProgressionEventPerkInfo(ProgressionEventPerkId id, ProgressionEventPerk perk)
        {
        }
    }
}