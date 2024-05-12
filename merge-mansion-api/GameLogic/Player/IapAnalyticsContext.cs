using Metaplay.Core.Model;
using System;

namespace GameLogic.Player
{
    [MetaSerializableDerived(6)]
    public class IapAnalyticsContext : AnalyticsContext
    {
        [MetaMember(10, (MetaMemberFlags)0)]
        public string OfferId { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public string TransactionId { get; set; }

        public IapAnalyticsContext()
        {
        }

        public IapAnalyticsContext(string context, string target, string offerId, string transactionId)
        {
        }
    }
}