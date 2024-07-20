using Metaplay.Core.Model;

namespace Metaplay.Core.League.Player
{
    [PlayerLeaguesEnabledCondition]
    [MetaSerializable]
    public abstract class PlayerDivisionActionBase : DivisionActionBase
    {
        protected PlayerDivisionActionBase()
        {
        }
    }
}