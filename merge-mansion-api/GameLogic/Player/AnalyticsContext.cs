using Metaplay.Core.Serialization;
using Metaplay.Core.Model;
using Metaplay.Core.Rewards;
using System;

namespace GameLogic.Player
{
    [MetaDeserializationConvertFromConcreteDerivedType(typeof(DefaultAnalyticsContext))]
    [MetaSerializable]
    [MetaReservedMembers(1, 9)]
    public abstract class AnalyticsContext : IRewardSource
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Context { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Target { get; set; }
        public static AnalyticsContext None { get; }

        protected AnalyticsContext()
        {
        }

        protected AnalyticsContext(string context, string target)
        {
        }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string FlashSaleContext { get; set; }

        protected AnalyticsContext(string context, string target, string flashSaleContext)
        {
        }

        public static string ContextIAP;
        private static string CardCollectionSource;
    }
}