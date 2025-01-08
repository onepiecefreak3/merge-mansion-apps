using Metaplay.Core.Model;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaFormHidden]
    [MetaSerializableDerived(16)]
    public class EmptyReward : PlayerReward
    {
        public EmptyReward()
        {
        }
    }
}