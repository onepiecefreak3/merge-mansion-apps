using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(14)]
    [MetaSerializable]
    public class RewardEventPoints : PlayerReward
    {
        [MetaMember(1, 0)]
        public EventId EventId { get; set; }
        [MetaMember(2, 0)]
        public int Amount { get; set; }
    }
}
