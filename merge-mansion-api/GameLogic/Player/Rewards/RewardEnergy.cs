using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(5)]
    [MetaSerializable]
    public class RewardEnergy : PlayerReward
    {
        [MetaMember(1, 0)]
        public int Amount { get; set; }
    }
}
