using Metaplay.Core.Model;

namespace Metaplay.Core.Rewards
{
    [UseCustomParserFromDerived]
    [MetaSerializable]
    public abstract class MetaPlayerRewardBase : MetaReward
    {
        protected MetaPlayerRewardBase()
        {
        }
    }
}