using Metaplay.Core.Config;
using Metaplay.Core.Model;
using System.Collections.Generic;
using System;
using GameLogic.Area;
using GameLogic.Player.Requirements;
using System.Runtime.Serialization;

namespace GameLogic.Config.Map.Characters
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 2, 3 })]
    public class MapCharacterEventDefinition : IGameConfigData<MapCharacterEventId>, IGameConfigData, IHasGameConfigKey<MapCharacterEventId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MapCharacterEventId MapCharacterEventId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MapCharacterType CharacterType { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MapCharacterDirection CharacterAppearDirection { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MapCharacterDirection CharacterActDirection { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public MapCharacterTransitionType CharacterAppearType { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public int Priority { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public MapCharacterPositionId CharacterPositionId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MapCharacterActType CharacterActType { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public MapCharacterMode CharacterMode { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public List<MapCharacterType> ResetMapCharacters { get; set; }

        public MapCharacterEventDefinition()
        {
        }

        [MetaMember(13, (MetaMemberFlags)0)]
        public string CharacterConfigId { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public string CharacterAnimationId { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public List<int> CharacterAppearRotation { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public List<int> CharacterActRotation { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public string SpeechBubbleLocalizationId { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        public MapSpotId MapSpotId { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        public List<string> CharacterPropActions { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        public List<PlayerRequirement> OpenRequirementsList { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public List<PlayerRequirement> CloseRequirementsList { get; set; }
        public MapCharacterEventId ConfigKey => MapCharacterEventId;

        [IgnoreDataMember]
        public List<PlayerRequirement> OpenRequirements { get; }

        [IgnoreDataMember]
        public List<PlayerRequirement> CloseRequirements { get; }

        public MapCharacterEventDefinition(MapCharacterEventId id, MapCharacterType mapCharacterType, MapCharacterActType mapCharacterActType, MapCharacterDirection mapCharacterAppearDirection, MapCharacterDirection mapCharacterActDirection, MapCharacterTransitionType mapCharacterAppearType, int priority, MapCharacterPositionId mapCharacterPositionId, MapCharacterMode mapCharacterMode, List<MapCharacterType> resetMapCharacters, string mapCharacterConfigId, string mapCharacterAnimationId, List<int> mapCharacterAppearRotation, List<int> mapCharacterActRotation, string speechBubbleLocalizationId, MapSpotId mapSpotId, List<string> mapCharacterPropActions, List<PlayerRequirement> openRequirements, List<PlayerRequirement> closeRequirements)
        {
        }
    }
}