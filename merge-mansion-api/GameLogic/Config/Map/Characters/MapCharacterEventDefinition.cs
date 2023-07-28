using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace GameLogic.Config.Map.Characters
{
    [MetaSerializable]
    public class MapCharacterEventDefinition : IGameConfigData<MapCharacterEventId>
    {
        [MetaMember(1, 0)]
        public MapCharacterEventId ConfigKey { get; set; }
        [MetaMember(2, 0)]
        public HotspotId OpensAtHotspot { get; set; }
        [MetaMember(3, 0)]
        public HotspotId ClosesAtHotspot { get; set; }
        [MetaMember(4, 0)]
        public MapCharacterType CharacterType { get; set; }
        [MetaMember(5, 0)]
        public MapCharacterDirection CharacterAppearDirection { get; set; }
        [MetaMember(6, 0)]
        public MapCharacterDirection CharacterActDirection { get; set; }
        [MetaMember(7, 0)]
        public MapCharacterTransitionType CharacterAppearType { get; set; }
        [MetaMember(8, 0)]
        public int Priority { get; set; }
        [MetaMember(9, 0)]
        public MapCharacterPositionId CharacterPositionId { get; set; }
	}
}
