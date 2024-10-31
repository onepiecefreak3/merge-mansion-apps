using Metaplay.Core.Model;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(16)]
    [MetaFormHidden]
    public class EmptyReward : PlayerReward
    {
        public EmptyReward()
        {
        }
    }
}