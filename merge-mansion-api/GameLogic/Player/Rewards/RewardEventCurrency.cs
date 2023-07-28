using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(12)]
    [MetaSerializable]
    public class RewardEventCurrency : PlayerReward
    {
        [MetaMember(1, 0)]
        public EventCurrencyId EventCurrencyId { get; set; }
        [MetaMember(2, 0)]
        public int Amount { get; set; }
    }
}
