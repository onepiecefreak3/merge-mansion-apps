using Metaplay.Core.Model;
using Metaplay.Core.Guild;

namespace Metaplay.Core.Rewards
{
    [UseCustomParserFromDerived]
    [MetaSerializable]
    [GuildsEnabledCondition]
    public abstract class MetaGuildRewardBase : MetaReward
    {
        protected MetaGuildRewardBase()
        {
        }
    }
}