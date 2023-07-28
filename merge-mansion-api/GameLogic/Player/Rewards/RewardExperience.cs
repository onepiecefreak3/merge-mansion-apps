using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class RewardExperience : PlayerReward
    {
        [MetaMember(1, 0)]
        public int Amount { get; set; }
    }
}
