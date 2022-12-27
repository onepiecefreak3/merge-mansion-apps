using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Decorations;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(11)]
    public class RewardDecoration : PlayerReward
    {
        [MetaMember(1, 0)]
        private MetaRef<DecorationInfo> DecorationRef { get; set; }

        public DecorationInfo Decoration => DecorationRef.Ref;
    }
}
