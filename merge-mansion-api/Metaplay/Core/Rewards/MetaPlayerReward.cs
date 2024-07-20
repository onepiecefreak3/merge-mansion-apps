using Metaplay.Core.Model;

namespace Metaplay.Core.Rewards
{
    [MetaSerializable]
    [UseCustomParserFromDerived]
    public abstract class MetaPlayerReward<TModel> : MetaPlayerRewardBase
    {
        protected MetaPlayerReward()
        {
        }
    }
}