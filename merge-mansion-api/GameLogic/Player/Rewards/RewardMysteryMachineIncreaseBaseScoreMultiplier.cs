using Metaplay.Core.Model;
using Metaplay.Core.Math;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(32)]
    public class RewardMysteryMachineIncreaseBaseScoreMultiplier : PlayerReward
    {
        [MetaFormFieldCustomValidator(typeof(RewardAmountValidator<F64>))]
        [MetaMember(1, (MetaMemberFlags)0)]
        public F64 ScoreMultiplierIncrease { get; set; }

        public RewardMysteryMachineIncreaseBaseScoreMultiplier()
        {
        }

        public RewardMysteryMachineIncreaseBaseScoreMultiplier(F64 scoreMultiplierIncrease)
        {
        }
    }
}