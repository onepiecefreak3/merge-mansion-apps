using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System;
using System.Runtime.Serialization;
using Metaplay.Core;

namespace GameLogic.Banks
{
    [MetaBlockedMembers(new int[] { 2 })]
    [MetaActivableSet("CurrencyBankEvent", false)]
    [MetaSerializableDerived(6)]
    public class CurrencyBanksModel : MetaActivableSet<CurrencyBankId, CurrencyBankInfo, CurrencyBankModel>
    {
        private static string ActivableKindId;
        [MetaMember(1, (MetaMemberFlags)0)]
        [ServerOnly]
        public string AnalyticsId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public CurrencyBankId LastNotedCurrencyBankId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public CurrencyBankState LastNotedCurrencyBankState { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int LastNotedCurrencyBankNumActivated { get; set; }

        [IgnoreDataMember]
        private int NumOfActivatedCurrencyBanks { get; }

        [IgnoreDataMember]
        private int NumOfConsumedCurrencyBanks { get; }

        public CurrencyBanksModel()
        {
        }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaTime? MostRecentCurrencyBankEndAt { get; set; }
    }
}