using Metaplay.Core;
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1003)]
    public class PlayerPropertyTimeSinceLastLogin : TypedPlayerPropertyId<MetaDuration>
    {
    }
}
