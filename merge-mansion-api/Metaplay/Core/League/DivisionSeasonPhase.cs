using Metaplay.Core.Model;

namespace Metaplay.Core.League
{
    [LeaguesEnabledCondition]
    [MetaSerializable]
    public enum DivisionSeasonPhase
    {
        NoDivision = 0,
        Preview = 1,
        Ongoing = 2,
        Resolving = 3,
        Concluded = 4
    }
}