using Metaplay.Core.Model;
using Metaplay.Core;
using Code.GameLogic.GameEvents;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(29)]
    public class RewardMysteryMachineEventProgress : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<MysteryMachineEventInfo> EventInfoRef { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [IgnoreDataMember]
        public MysteryMachineEventId EventId { get; }

        public RewardMysteryMachineEventProgress()
        {
        }

        public RewardMysteryMachineEventProgress(MysteryMachineEventId eventId, int amount, CurrencySource currencySource)
        {
        }
    }
}