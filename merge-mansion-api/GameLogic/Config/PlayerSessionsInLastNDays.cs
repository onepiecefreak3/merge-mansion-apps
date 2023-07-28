using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1020)]
    public class PlayerSessionsInLastNDays : TypedPlayerPropertyId<int>
    {
    }
}
