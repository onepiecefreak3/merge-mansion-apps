using Metaplay.Core.Model;
using GameLogic.Mail;
using System;
using Metaplay.Core.Forms;
using Metaplay.Core;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Analytics;

namespace Game.Logic
{
    [MetaSerializableDerived(11)]
    [MetaReservedMembers(0, 80)]
    [Obsolete("MM Internal Survey System (Messy) no longer in use, left for compatibility reasons")]
    public class SurveyInGameMail : MergeMansionMailContents, IBroadcastMailMessage
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int SurveyId { get; set; }

        [MetaFormNotEditable]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string Token { get; set; }

        [MetaFormNotEditable]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string SurveyDataAddress { get; set; }

        [MetaFormNotEditable]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string ResultAddress { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaTime ExpireAt { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string ExcerptTopic { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        private List<PlayerReward> PromisedReward { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<int, string> Questions { get; set; }
        public override string TitleExcerpt { get; }
        public override string BodyExcerpt { get; }
        public override IEnumerable<PlayerReward> Rewards { get; }
        public int BroadcastId { get; }
        public bool TrackImpressions { get; }
        public override string Description { get; }

        public SurveyInGameMail()
        {
        }

        public SurveyInGameMail(int surveyId, string token, string surveyDataAddress, string resultAddress, string excerptTopic, MetaTime expireAt, IEnumerable<PlayerReward> promisedReward, Dictionary<int, string> questions, MailDeliveryFilters deliveryFilters)
        {
        }
    }
}