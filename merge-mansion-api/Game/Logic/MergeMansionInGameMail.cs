using Metaplay.Core.Model;
using GameLogic.Mail;
using System;
using Metaplay.Core.Forms;
using Metaplay.Core.Localization;
using System.Collections.Generic;
using GameLogic;
using GameLogic.Player.Rewards;
using Metaplay.Core;

namespace Game.Logic
{
    [MetaSerializableDerived(10)]
    [MetaReservedMembers(0, 80)]
    public class MergeMansionInGameMail : MergeMansionMailContents, IBroadcastMailMessage
    {
        private static int ShortTopicLimit;
        private static int ShortContentLimit;
        [MetaValidateRequired]
        [MetaMember(1, (MetaMemberFlags)0)]
        public LocalizedString ExcerptTopic { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [MetaFormTextArea]
        [MetaValidateRequired]
        public LocalizedString ExcerptContent { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [MetaValidateRequired]
        public LocalizedString FullTopic { get; set; }

        [MetaValidateRequired]
        [MetaMember(4, (MetaMemberFlags)0)]
        [MetaFormTextArea]
        public LocalizedString FullContent { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string ExcerptImageFile { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string FullImageFile { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [MetaFormFieldContext("AttachmentRewardList", true)]
        public List<PlayerReward> Attachments { get; set; }

        [MetaFormNotEditable]
        [MetaMember(8, (MetaMemberFlags)0)]
        public long EndDay { get; set; }

        [MetaFormNotEditable]
        [MetaMember(9, (MetaMemberFlags)0)]
        public int BroadcastNo { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [MetaFormFieldCustomValidator(typeof(MergeMansionInGameMail.SocialMediaPlatformValidator))]
        public List<SocialMediaPlatform> SocialMediaButtonsToShow { get; set; }

        [MetaFormNotEditable]
        [MetaMember(11, (MetaMemberFlags)0)]
        public MergeMansionInGameMailContentType ContentType { get; set; }

        [MetaFormNotEditable]
        [MetaMember(12, (MetaMemberFlags)0)]
        public string ContentExtra { get; set; }
        public override string TitleExcerpt { get; }
        public override string BodyExcerpt { get; }
        public override IEnumerable<PlayerReward> Rewards { get; }
        public override bool RewardsGivenInConsumeMail { get; }
        public int BroadcastId { get; }
        public bool TrackImpressions { get; }

        public MergeMansionInGameMail()
        {
        }

        public MergeMansionInGameMail(MetaGuid guid)
        {
        }

        public MergeMansionInGameMail(string messageTopic, string messageContent, List<PlayerReward> attachments, long endDay, LanguageId language, int broadcastId)
        {
        }

        public MergeMansionInGameMail(string messageTopic, string messageTopicExcerpt, string messageContent, string messageContentExcerpt, List<PlayerReward> attachments, long endDay, LanguageId language)
        {
        }

        public class SocialMediaPlatformValidator : MetaFormValidator<List<SocialMediaPlatform>>
        {
            public SocialMediaPlatformValidator()
            {
            }
        }
    }
}