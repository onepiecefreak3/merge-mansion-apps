using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using Metaplay.Core.InGameMail;
using System;
using System.Collections.Generic;
using GameLogic;
using Metaplay.Core.Rewards;
using GameLogic.Player.Rewards;

namespace Game.Logic
{
    [MetaFormDeprecated]
    [MetaBlockedMembers(new int[] { 111 })]
    [MetaReservedMembers(102, 200)]
    [MetaSerializableDerived(3)]
    [MetaReservedMembers(100, 101)]
    public class LegacyMergeMansionInGameMail : MetaInGameMail
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public int LegacyId { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public InboxItemStatus Status { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        public string ExcerptTopic { get; set; }

        [MetaMember(104, (MetaMemberFlags)0)]
        public string ExcerptContent { get; set; }

        [MetaMember(105, (MetaMemberFlags)0)]
        public string FullTopic { get; set; }

        [MetaMember(106, (MetaMemberFlags)0)]
        public string FullContent { get; set; }

        [MetaMember(107, (MetaMemberFlags)0)]
        public string ExcerptImageFile { get; set; }

        [MetaMember(108, (MetaMemberFlags)0)]
        public string FullImageFile { get; set; }

        [MetaMember(109, (MetaMemberFlags)0)]
        public long StartDay { get; set; }

        [MetaMember(110, (MetaMemberFlags)0)]
        public long EndDay { get; set; }

        [MetaMember(112, (MetaMemberFlags)0)]
        public List<MetaPlayerRewardBase> Attachments { get; set; }

        [MetaMember(113, (MetaMemberFlags)0)]
        public bool LocalizeInClientOld { get; set; }

        [MetaMember(114, (MetaMemberFlags)0)]
        public string LocalizationPrefixId { get; set; }

        [MetaMember(115, (MetaMemberFlags)0)]
        public bool CanBeDeleted { get; set; }

        [MetaMember(116, (MetaMemberFlags)0)]
        public MailDeliveryFilters DeliveryFilters { get; set; }
        public string TitleExcerpt { get; }
        public string BodyExcerpt { get; }
        public IEnumerable<PlayerReward> Rewards { get; }
        public override string Description { get; }
        public override IEnumerable<MetaPlayerRewardBase> ConsumableRewards { get; }

        private LegacyMergeMansionInGameMail()
        {
        }
    }
}