using Metaplay.Core.Model;
using Metaplay.Core.InGameMail;
using Newtonsoft.Json;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Rewards;
using System;
using Metaplay.Core;

namespace Game.Logic
{
    [MetaReservedMembers(80, 100)]
    public abstract class MergeMansionMailContents : MetaInGameMail
    {
        [MetaMember(80, (MetaMemberFlags)0)]
        public MailDeliveryFilters DeliveryFilters { get; set; }

        [JsonIgnore]
        public abstract IEnumerable<PlayerReward> Rewards { get; }
        public override IEnumerable<MetaPlayerRewardBase> ConsumableRewards { get; }
        public override bool MustBeConsumed { get; }
        public override string Description { get; }

        [JsonIgnore]
        public abstract string TitleExcerpt { get; }

        [JsonIgnore]
        public abstract string BodyExcerpt { get; }

        [JsonIgnore]
        public virtual bool RewardsGivenInConsumeMail { get; }

        protected MergeMansionMailContents()
        {
        }

        protected MergeMansionMailContents(MetaGuid guid)
        {
        }
    }
}