using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(18)]
    [MetaSerializable]
    public class ProgressionEventPerkReward : PlayerReward
    {
        [MetaMember(1, 0)]
        public ProgressionEventPerkId PerkId { get; set; }

        public ProgressionEventPerkReward()
        {
        }

        public ProgressionEventPerkReward(ProgressionEventPerkId perkId)
        {
        }
    }
}