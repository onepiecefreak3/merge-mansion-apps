using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(3)]
    [MetaSerializable]
    public class RewardDiamonds : PlayerReward
    {
        [MetaMember(1, 0)]
        public int Amount { get; set; }
    }
}
