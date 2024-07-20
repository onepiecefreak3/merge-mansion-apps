using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Area;

namespace GameLogic.Config.Map.Characters
{
    public class MapCharacterEventDefinitionSource : IConfigItemSource<MapCharacterEventDefinition, MapCharacterEventId>, IGameConfigSourceItem<MapCharacterEventId, MapCharacterEventDefinition>, IHasGameConfigKey<MapCharacterEventId>
    {
        private MapCharacterEventId MapCharacterEventId { get; set; }
        private MapCharacterType CharacterType { get; set; }
        private MapCharacterActType CharacterActType { get; set; }
        private MapCharacterDirection CharacterAppearDirection { get; set; }
        private MapCharacterDirection CharacterActDirection { get; set; }
        private MapCharacterTransitionType CharacterAppearType { get; set; }
        private int Priority { get; set; }
        private MapCharacterPositionId CharacterPositionId { get; set; }
        private MapCharacterMode CharacterMode { get; set; }
        private List<MapCharacterType> ResetMapCharacters { get; set; }
        private string CharacterConfigId { get; set; }
        private string CharacterAnimationId { get; set; }
        private List<int> CharacterAppearRotation { get; set; }
        private List<int> CharacterActRotation { get; set; }
        private string SpeechBubbleLocalizationId { get; set; }
        private MapSpotId MapSpotId { get; set; }
        private List<string> CharacterPropActions { get; set; }
        private List<string> OpenRequirementType { get; set; }
        private List<string> OpenRequirementId { get; set; }
        private List<string> OpenRequirementAmount { get; set; }
        private List<string> OpenRequirementAux0 { get; set; }
        private List<string> CloseRequirementType { get; set; }
        private List<string> CloseRequirementId { get; set; }
        private List<string> CloseRequirementAmount { get; set; }
        private List<string> CloseRequirementAux0 { get; set; }
        public MapCharacterEventId ConfigKey { get; }

        public MapCharacterEventDefinitionSource()
        {
        }
    }
}