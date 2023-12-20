using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(25)]
    public class RewardPet : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<PetInfo> PetRef { get; set; }
        public PetId PetId { get; }
        public PetInfo PetInfo { get; }

        public RewardPet()
        {
        }

        public RewardPet(PetId petId, CurrencySource currencySource)
        {
        }
    }
}