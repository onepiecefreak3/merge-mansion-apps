using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1000)]
    public class PlayerPropertyLastKnownCountry : TypedPlayerPropertyId<string>
    {
    }
}
