using Metaplay.Core.Model;

namespace Metaplay.Core.Rewards
{
    [MetaSerializable]
    [UseCustomParserFromDerived]
    public abstract class MetaPlayerRewardBase : MetaReward
    {
        protected MetaPlayerRewardBase()
        {
        }
    }
}