using Metaplay.GameLogic.Merge;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Player;

namespace merge_mansion_api.GameLogic.Config
{
    [MetaSerializableDerived(1006)]
    public class PlayerPropertyEventProgressReachedLevel : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        public MergeBoardId MergeBoardId; // 0x10
    }
}
