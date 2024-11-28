using Metaplay.Core.Model;
using Metaplay.Core;
using Code.GameLogic.GameEvents;
using System;
using System.Runtime.Serialization;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(27)]
    public class RewardSideBoardEventProgress : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<SideBoardEventInfo> EventInfoRef { get; set; }

        [MetaFormFieldCustomValidator(typeof(RewardAmountValidator<int>))]
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [IgnoreDataMember]
        public SideBoardEventId EventId { get; }

        public RewardSideBoardEventProgress()
        {
        }

        public RewardSideBoardEventProgress(SideBoardEventId eventId, int amount, CurrencySource currencySource)
        {
        }
    }
}