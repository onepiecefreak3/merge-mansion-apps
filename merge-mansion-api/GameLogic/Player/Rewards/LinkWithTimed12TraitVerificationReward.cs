using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(10)]
    public class LinkWithTimed12TraitVerificationReward : PlayerReward
    {
        [MetaMember(1, 0)]
        public string Link { get; set; }
        [MetaMember(2, 0)]
        public Currencies Currency { get; set; }
        [MetaMember(3, 0)]
        public long RewardAmount { get; set; }
        [MetaMember(4, 0)]
        public MetaTime EndTime { get; set; }
        [MetaMember(5, 0)]
        public bool ReadyToClaim { get; set; }
	}
}
