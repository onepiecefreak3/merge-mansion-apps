using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1032)]
    [MetaSerializable]
    public class PlayerPointsInCollectibleBoardEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        private CollectibleBoardEventId EventId { get; set; }
    }
}
