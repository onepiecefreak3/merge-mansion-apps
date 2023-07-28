using Metaplay.Core;
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1001)]
    public class PlayerPropertyAccountCreatedAt : TypedPlayerPropertyId<MetaTime>
    {
    }
}
