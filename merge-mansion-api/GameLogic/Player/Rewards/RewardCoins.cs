using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class RewardCoins : PlayerReward
    {
        [MetaMember(1, 0)]
        public int Amount { get; set; }
    }
}
