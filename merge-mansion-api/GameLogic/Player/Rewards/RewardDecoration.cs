using GameLogic.Decorations;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(11)]
    [MetaSerializable]
    public class RewardDecoration : PlayerReward
    {
        [MetaMember(1, 0)]
        private MetaRef<DecorationInfo> DecorationRef { get; set; }

        public DecorationInfo Decoration => DecorationRef.Ref;
    }
}
