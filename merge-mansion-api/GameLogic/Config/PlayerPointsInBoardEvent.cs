using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1030)]
    [MetaSerializable]
    public class PlayerPointsInBoardEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        private EventId EventId { get; set; }
    }
}
