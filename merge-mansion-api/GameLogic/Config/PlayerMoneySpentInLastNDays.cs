using Metaplay.Core.Math;
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1035)]
    [MetaSerializable]
    public class PlayerMoneySpentInLastNDays : TypedPlayerPropertyId<F64>
    {
        [MetaMember(1, 0)]
        private int Days { get; set; }
    }
}
