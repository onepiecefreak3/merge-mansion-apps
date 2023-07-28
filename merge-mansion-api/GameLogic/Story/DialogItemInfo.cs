using System.Collections.Generic;
using GameLogic.Config.Map.Characters;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace GameLogic.Story
{
    [MetaSerializable]
    public class DialogItemInfo : IGameConfigData<DialogItemId>
    {
        [MetaMember(1, 0)]
        public DialogItemId DialogItemId { get; set; }
        [MetaMember(2, 0)]
        public string LocalizationId { get; set; }
        [MetaMember(3, 0)]
        public DialogMode DialogMode { get; set; }
        [MetaMember(4, 0)]
        public DialogCharacterState LeftCharacterState { get; set; }
        [MetaMember(5, 0)]
        public DialogCharacterType LeftCharacter { get; set; }
        [MetaMember(6, 0)]
        public bool LeftSpeaks { get; set; }
        [MetaMember(7, 0)]
        public bool RightSpeaks { get; set; }
        [MetaMember(8, 0)]
        public DialogCharacterType RightCharacter { get; set; }
        [MetaMember(9, 0)]
        public DialogCharacterState RightCharacterState { get; set; }
        [MetaMember(10, 0)]
        public bool WaitConfirmation { get; set; }
        [MetaMember(11, 0)]
        public CameraTargetName ScrollToCameraTarget { get; set; }
        [MetaMember(12, 0)]
        public bool WaitForEndOfScrolling { get; set; }
        [MetaMember(13, 0)]
        public CameraZoomTarget CameraZoomTarget { get; set; }
        [MetaMember(14, 0)]
        public bool NeedsTransition { get; set; }
        [MetaMember(15, 0)]
        public CameraTargetName MoveToCameraTarget { get; set; }
        [MetaMember(17, 0)]
        public HotspotId ActivateHotSpot { get; set; }
        [MetaMember(18, 0)]
        public List<DialogLayoutEvent> LayoutEvents { get; set; }
        [MetaMember(19, 0)]
        public string AnimationGameObjectName { get; set; }
        [MetaMember(20, 0)]
        public string AnimationTrackName { get; set; }
        [MetaMember(21, 0)]
        public string AnimationSpineName { get; set; }
        [MetaMember(22, 0)]
        public string AnimationFinalState { get; set; }
        [MetaMember(23, 0)]
        public List<MetaRef<MapCharacterEventDefinition>> MapCharactersEventsRefs { get; set; }
        [MetaMember(24, 0)]
        public List<MapCharacterType> ResetMapCharacters { get; set; }
        [MetaMember(25, 0)]
        public List<HotspotId> ScrollToHotSpot { get; set; }
        [MetaMember(26, 0)]
        public List<DialogCharacterType> DiscoveredCharacters { get; set; }

        public DialogItemId ConfigKey => DialogItemId;
    }
}
