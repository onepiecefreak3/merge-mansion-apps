using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using Metaplay.Core;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Banks
{
    [MetaSerializableDerived(7)]
    public class CurrencyBankModel : MetaActivableState<CurrencyBankId, CurrencyBankInfo>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override CurrencyBankId ActivableId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime? FullStateStartedAt { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int StoredAmount { get; set; }

        [IgnoreDataMember]
        public CurrencyBankInfo Info { get; }

        private CurrencyBankModel()
        {
        }

        public CurrencyBankModel(CurrencyBankInfo info)
        {
        }
    }
}