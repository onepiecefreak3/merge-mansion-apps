using Metaplay.Core.Model;

namespace Metaplay.Core.Rewards
{
    [UseCustomParserFromDerived]
    [MetaSerializable]
    public abstract class MetaPlayerReward<TModel> : MetaPlayerRewardBase
    {
        protected MetaPlayerReward()
        {
        }
    }
}