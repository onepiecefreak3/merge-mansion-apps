using Metaplay.Core.Model;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(4)]
    public class MysteryMachineMultiplyScoreMultiplierPerk : IMysteryMachinePerk
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public F64 Multiplier { get; set; }

        private MysteryMachineMultiplyScoreMultiplierPerk()
        {
        }

        public MysteryMachineMultiplyScoreMultiplierPerk(F64 multiplier)
        {
        }
    }
}