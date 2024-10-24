using Metaplay.Core.Model;

namespace Metaplay.Core.League.Player
{
    [MetaSerializable]
    [PlayerLeaguesEnabledCondition]
    public abstract class PlayerDivisionActionBase : DivisionActionBase
    {
        protected PlayerDivisionActionBase()
        {
        }
    }
}