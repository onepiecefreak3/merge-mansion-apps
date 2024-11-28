using GameLogic.Decorations;
using Metaplay.Core;
using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(21)]
    public class RewardLayeredDecoration : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [MetaValidateRequired]
        private MetaRef<DecorationInfo> DecorationRef { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Progress { get; set; }

        [IgnoreDataMember]
        public DecorationInfo Decoration { get; }

        [IgnoreDataMember]
        public bool WillOwnDecoration { get; }

        public RewardLayeredDecoration()
        {
        }

        public RewardLayeredDecoration(DecorationId setId, int progress, CurrencySource currencySource)
        {
        }
    }
}