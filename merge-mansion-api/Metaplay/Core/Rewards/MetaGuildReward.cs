using Metaplay.Core.Model;

namespace Metaplay.Core.Rewards
{
    [MetaSerializable]
    [UseCustomParserFromDerived]
    public abstract class MetaGuildReward<TModel> : MetaGuildRewardBase
    {
        protected MetaGuildReward()
        {
        }
    }
}