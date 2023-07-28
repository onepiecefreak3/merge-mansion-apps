using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(15)]
    [MetaSerializable]
    public class RewardExtendGameEvents : PlayerReward
    {
        [MetaMember(1, 0)]
        public EventId EventId { get; set; }
    }
}
