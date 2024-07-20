using GameLogic.Decorations;
using Metaplay.Core;
using Metaplay.Core.Model;
using System.Runtime.Serialization;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(11)]
    public class RewardDecoration : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<DecorationInfo> DecorationRef { get; set; }
        public DecorationInfo Decoration => DecorationRef.Ref;

        public RewardDecoration()
        {
        }

        public RewardDecoration(DecorationInfo decorationInfo, CurrencySource currencySource)
        {
        }

        public RewardDecoration(DecorationId decorationId, CurrencySource currencySource)
        {
        }
    }
}