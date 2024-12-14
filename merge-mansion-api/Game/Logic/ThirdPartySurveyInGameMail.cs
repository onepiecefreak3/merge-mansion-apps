using Metaplay.Core.Model;
using GameLogic.Mail;
using System;
using Metaplay.Core.Forms;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Localization;
using Metaplay.Core;

namespace Game.Logic
{
    [MetaSerializableDerived(13)]
    public class ThirdPartySurveyInGameMail : MergeMansionMailContents, IBroadcastMailMessage
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int SurveyId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Url { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [MetaFormFieldContext("AttachmentRewardList", true)]
        public List<PlayerReward> StartingRewards { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [MetaFormFieldContext("AttachmentRewardList", true)]
        public List<PlayerReward> CompletingRewards { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public LocalizedString ExcerptTopic { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public LocalizedString ExcerptContent { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public LocalizedString FullTopic { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public LocalizedString FullContent { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public MetaTime EndDate { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public string SurveyType { get; set; }
        public int BroadcastId { get; }
        public bool TrackImpressions { get; }
        public override IEnumerable<PlayerReward> Rewards { get; }
        public override string TitleExcerpt { get; }
        public override string BodyExcerpt { get; }
        public override bool RewardsGivenInConsumeMail { get; }

        private ThirdPartySurveyInGameMail()
        {
        }

        public ThirdPartySurveyInGameMail(string topic, string content, string excerptTopic, string excerptContent, string url, int broadcastId, LanguageId language, MetaTime endDate, string surveyType, List<PlayerReward> startingRewards, List<PlayerReward> completingRewards, MailDeliveryFilters deliveryFilters)
        {
        }
    }
}