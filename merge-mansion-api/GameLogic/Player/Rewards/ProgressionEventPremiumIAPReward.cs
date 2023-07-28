using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(17)]
    [MetaSerializable]
    public class ProgressionEventPremiumIAPReward : PlayerReward
    {
        [MetaMember(1, 0)]
        public ProgressionEventId EventId { get; set; }
    }
}
