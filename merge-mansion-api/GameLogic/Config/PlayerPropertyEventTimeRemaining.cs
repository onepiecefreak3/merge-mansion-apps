using Metaplay.Core;
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1011)]
    public class PlayerPropertyEventTimeRemaining : TypedPlayerPropertyId<MetaDuration>
    {
    }
}
