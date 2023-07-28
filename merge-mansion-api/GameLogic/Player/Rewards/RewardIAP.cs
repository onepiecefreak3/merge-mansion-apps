using GameLogic.IAP;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(7)]
    [MetaSerializable]
    public class RewardIAP : PlayerReward
    {
        [MetaMember(1, 0)]
        public IAPTags IAPTag { get; set; }
    }
}
