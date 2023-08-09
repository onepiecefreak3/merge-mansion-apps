using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic
{
    [MetaSerializable]
    public class SocialMediaRewardDefinition
    {
        public static string EventComment;
        public static string EventLike;
        [MetaMember(1, (MetaMemberFlags)0)]
        public SocialMediaPlatform Type { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string PostId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Event { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string TopicId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string MessageId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public ShopItemId ItemId { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<ItemAmountPair> Items { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<CurrencyAmountPair> Currencies { get; set; }
        public SocialMediaRewardId ConfigKey { get; }

        public SocialMediaRewardDefinition()
        {
        }

        public SocialMediaRewardDefinition(SocialMediaPlatform type, string postId, string eventType, string topicId, string messageId, string itemId, List<ItemAmountPair> items, List<CurrencyAmountPair> currencies)
        {
        }
    }
}