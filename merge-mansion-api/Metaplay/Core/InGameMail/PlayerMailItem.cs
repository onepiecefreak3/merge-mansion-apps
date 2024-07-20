using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.InGameMail
{
    [MetaReservedMembers(100, 200)]
    [MetaSerializable]
    public abstract class PlayerMailItem
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        private MetaInGameMail _contents;
        [MetaMember(101, (MetaMemberFlags)0)]
        public MetaTime SentAt { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public bool HasBeenConsumed { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        public MetaTime ConsumedAt { get; set; }

        [MetaMember(104, (MetaMemberFlags)0)]
        public bool IsRead { get; set; }

        [MetaMember(105, (MetaMemberFlags)0)]
        public MetaTime ReadAt { get; set; }
        public MetaInGameMail Contents { get; }
        public MetaGuid Id { get; }

        protected PlayerMailItem()
        {
        }

        protected PlayerMailItem(MetaInGameMail contents, MetaTime sentAt)
        {
        }
    }
}