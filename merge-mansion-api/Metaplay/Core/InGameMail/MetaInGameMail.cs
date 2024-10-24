using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Metaplay.Core.InGameMail
{
    [MetaSerializable]
    [MetaFormDerivedMembersOnly]
    [MetaFormUseAsContext]
    [MetaReservedMembers(101, 102)]
    [MetaReservedMembers(200, 300)]
    public abstract class MetaInGameMail
    {
        [MetaMember(200, (MetaMemberFlags)0)]
        public MetaGuid Id { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public MetaTime CreatedAt { get; set; }
        public abstract string Description { get; }

        [JsonProperty(TypeNameHandling = (TypeNameHandling)0)]
        public virtual IEnumerable<MetaPlayerRewardBase> ConsumableRewards { get; }
        public virtual bool MustBeConsumed { get; }
        public virtual bool LocalizeInClient { get; }

        protected MetaInGameMail()
        {
        }

        protected MetaInGameMail(MetaGuid maildId)
        {
        }
    }
}