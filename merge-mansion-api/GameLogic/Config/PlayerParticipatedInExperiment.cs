using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1023)]
    public class PlayerParticipatedInExperiment : TypedPlayerPropertyId<bool>
    {
    }
}
