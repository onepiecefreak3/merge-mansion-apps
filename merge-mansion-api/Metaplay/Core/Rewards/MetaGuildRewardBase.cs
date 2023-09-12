using Metaplay.Core.Model;
using Metaplay.Core.Guild;

namespace Metaplay.Core.Rewards
{
    [MetaSerializable]
    [UseCustomParserFromDerived]
    [GuildsEnabledCondition]
    public abstract class MetaGuildRewardBase : MetaReward
    {
        protected MetaGuildRewardBase()
        {
        }
    }
}