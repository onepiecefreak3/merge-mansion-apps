using Metaplay.Core.Model;

namespace Metaplay.Core.Rewards
{
    [UseCustomParserFromDerived]
    [MetaSerializable]
    public abstract class MetaGuildReward<TModel> : MetaGuildRewardBase
    {
        protected MetaGuildReward()
        {
        }
    }
}