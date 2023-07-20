using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.IAP;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(7)]
    [MetaSerializable]
    public class RewardIAP : PlayerReward
    {
        [MetaMember(1, 0)]
        public IAPTags IAPTag { get; set; }
    }
}
