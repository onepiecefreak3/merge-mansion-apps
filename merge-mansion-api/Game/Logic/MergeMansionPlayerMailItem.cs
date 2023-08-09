using Metaplay.Core.Model;
using Metaplay.Core.InGameMail;
using Game.Logic.Mail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using GameLogic;
using GameLogic.Player.Rewards;
using Metaplay.Core;

namespace Game.Logic
{
    [MetaSerializableDerived(1)]
    public class MergeMansionPlayerMailItem : PlayerMailItem, IMailMessage
    {
        public MergeMansionMailContents Contents { get; }
        public InboxItemStatus Status { get; }

        [JsonIgnore]
        public string TitleExcerpt { get; }

        [JsonIgnore]
        public string BodyExcerpt { get; }

        [JsonIgnore]
        public IEnumerable<PlayerReward> Rewards { get; }

        [JsonIgnore]
        MergeMansionMailContents Game.Logic.Mail.IMailMessage.Contents { get; }

        public MergeMansionPlayerMailItem()
        {
        }

        public MergeMansionPlayerMailItem(MergeMansionMailContents contents, MetaTime sentAt)
        {
        }
    }
}