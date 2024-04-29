using Metaplay.Core.Model;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(1)]
    public class MysteryMachineIncreaseScoreMultiplierPerk : IMysteryMachinePerk
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public F64 ScoreMultiplierIncrease { get; set; }

        private MysteryMachineIncreaseScoreMultiplierPerk()
        {
        }

        public MysteryMachineIncreaseScoreMultiplierPerk(F64 scoreMultiplierIncrease)
        {
        }
    }
}