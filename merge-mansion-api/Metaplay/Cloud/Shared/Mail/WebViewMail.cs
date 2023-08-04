using Metaplay.Core.Model;
using Game.Logic;
using GameLogic.Mail;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace Metaplay.Cloud.Shared.Mail
{
    [MetaReservedMembers(0, 80)]
    [MetaSerializableDerived(12)]
    public class WebViewMail : MergeMansionMailContents, IBroadcastMailMessage
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Title { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Body { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Url { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<PlayerReward> Attachments { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int BroadcastId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string PreviewImageId { get; set; }
        public bool TrackImpressions { get; }
        public override IEnumerable<PlayerReward> Rewards { get; }
        public override string TitleExcerpt { get; }
        public override string BodyExcerpt { get; }

        public WebViewMail()
        {
        }

        public WebViewMail(int broadcastId, string titleExcerpt, string bodyExcerpt, string url, List<PlayerReward> attachments, MailDeliveryFilters deliveryFilters, string previewImageId)
        {
        }
    }
}