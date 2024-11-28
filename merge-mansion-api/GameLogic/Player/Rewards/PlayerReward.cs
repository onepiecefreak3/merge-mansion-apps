using Metaplay.Core.Model;
using Metaplay.Core.Rewards;
using Code.GameLogic.Config;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializable]
    public abstract class PlayerReward : MetaPlayerRewardBase, IValidatable
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public CurrencySource Source { get; set; }

        protected PlayerReward()
        {
        }

        [IgnoreDataMember]
        public virtual bool ShouldShowInfoButton { get; }
    }
}