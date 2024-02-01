using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.EventCharacters;
using System.Runtime.Serialization;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(28)]
    public class RewardEventCharacter : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<EventCharacterInfo> EventCharacterRef { get; set; }

        [IgnoreDataMember]
        public EventCharacterInfo EventCharacter { get; }

        public RewardEventCharacter()
        {
        }

        public RewardEventCharacter(EventCharacterInfo eventCharacterInfo, CurrencySource currencySource)
        {
        }

        public RewardEventCharacter(EventCharacterId eventCharacterId, CurrencySource currencySource)
        {
        }
    }
}