using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ProgressionEventPerkInfo : IGameConfigData<ProgressionEventPerkId>
    {
        [MetaMember(1, 0)]
        public ProgressionEventPerkId Id { get; set; }
        [MetaMember(2, 0)]
        public ProgressionEventPerk Perk { get; set; }

        public ProgressionEventPerkId ConfigKey => Id;
    }
}
