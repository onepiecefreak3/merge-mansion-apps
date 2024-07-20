using Metaplay.Core.Model;
using Metaplay.Core.Guild;

namespace Metaplay.Core.Rewards
{
    [MetaSerializable]
    [GuildsEnabledCondition]
    [UseCustomParserFromDerived]
    public abstract class MetaGuildRewardBase : MetaReward
    {
        protected MetaGuildRewardBase()
        {
        }
    }
}