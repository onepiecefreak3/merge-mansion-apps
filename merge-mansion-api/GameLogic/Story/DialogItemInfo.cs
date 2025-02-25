using System.Collections.Generic;
using GameLogic.Config.Map.Characters;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Code.GameLogic.Config;
using System.Runtime.Serialization;
using System;
using GameLogic.Player.Director.Config;
using System.Runtime.CompilerServices;

namespace GameLogic.Story
{
    [MetaBlockedMembers(new int[] { 16 })]
    [MetaSerializable]
    public class DialogItemInfo : IGameConfigData<DialogItemId>, IGameConfigData, IHasGameConfigKey<DialogItemId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DialogItemId DialogItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string LocalizationId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public DialogMode DialogMode { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public DialogCharacterState LeftCharacterState { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public DialogCharacterType LeftCharacter { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public bool LeftSpeaks { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public bool RightSpeaks { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public DialogCharacterType RightCharacter { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public DialogCharacterState RightCharacterState { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public bool WaitConfirmation { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public CameraTargetName ScrollToCameraTarget { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public bool WaitForEndOfScrolling { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public CameraZoomTarget CameraZoomTarget { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public bool NeedsTransition { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public CameraTargetName MoveToCameraTarget { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public HotspotId ActivateHotSpot { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        public List<DialogLayoutEvent> LayoutEvents { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        public string AnimationGameObjectName { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        public string AnimationTrackName { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public string AnimationSpineName { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        public string AnimationFinalState { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        public List<MetaRef<MapCharacterEventDefinition>> MapCharactersEventsRefs { get; set; }

        [MetaMember(24, (MetaMemberFlags)0)]
        public List<MapCharacterType> ResetMapCharacters { get; set; }

        [MetaMember(25, (MetaMemberFlags)0)]
        public List<HotspotId> ScrollToHotSpot { get; set; }

        [MetaMember(26, (MetaMemberFlags)0)]
        public List<DialogCharacterType> DiscoveredCharacters { get; set; }
        public DialogItemId ConfigKey => DialogItemId;

        [IgnoreDataMember]
        public ValueTuple<string, string, string, string> AnimationFormat { get; }

        [IgnoreDataMember]
        public IEnumerable<MapCharacterEventDefinition> MapCharactersEvents { get; }

        public DialogItemInfo()
        {
        }

        public DialogItemInfo(DialogItemId dialogItemId, string localizationId, DialogMode dialogMode, DialogCharacterState leftCharacterState, DialogCharacterType leftCharacter, bool leftSpeaks, DialogCharacterState rightCharacterState, DialogCharacterType rightCharacter, bool rightSpeaks, bool waitConfirmation, CameraTargetName scrollToCameraTarget, bool waitForEndOfScrolling, CameraZoomTarget cameraZoomTarget, bool needsTransition, CameraTargetName moveToCameraTarget, List<HotspotId> scrollToHotSpot, HotspotId activateHotSpot, List<DialogLayoutEvent> layoutEvents, string animationGameObjectName, string animationTrackName, string animationSpineName, string animationFinalState, List<MetaRef<MapCharacterEventDefinition>> mapCharactersEvents, List<MapCharacterType> resetMapCharacters, List<DialogCharacterType> discoveredCharacters)
        {
        }

        [MetaMember(27, (MetaMemberFlags)0)]
        public bool DisallowClose { get; set; }

        [MetaMember(28, (MetaMemberFlags)0)]
        public List<IDirectorAction> StartActions { get; set; }

        public DialogItemInfo(DialogItemId dialogItemId, string localizationId, DialogMode dialogMode, DialogCharacterState leftCharacterState, DialogCharacterType leftCharacter, bool leftSpeaks, DialogCharacterState rightCharacterState, DialogCharacterType rightCharacter, bool rightSpeaks, bool waitConfirmation, CameraTargetName scrollToCameraTarget, bool waitForEndOfScrolling, CameraZoomTarget cameraZoomTarget, bool needsTransition, CameraTargetName moveToCameraTarget, List<HotspotId> scrollToHotSpot, HotspotId activateHotSpot, List<DialogLayoutEvent> layoutEvents, string animationGameObjectName, string animationTrackName, string animationSpineName, string animationFinalState, List<MetaRef<MapCharacterEventDefinition>> mapCharactersEvents, List<MapCharacterType> resetMapCharacters, List<DialogCharacterType> discoveredCharacters, bool disallowClose, List<IDirectorAction> startActions)
        {
        }

        [MetaMember(29, (MetaMemberFlags)0)]
        public string LeftCharacterConfigId { get; set; }

        [MetaMember(30, (MetaMemberFlags)0)]
        public string RightCharacterConfigId { get; set; }

        public DialogItemInfo(DialogItemId dialogItemId, string localizationId, DialogMode dialogMode, DialogCharacterState leftCharacterState, DialogCharacterType leftCharacter, bool leftSpeaks, string leftCharacterConfigId, DialogCharacterState rightCharacterState, DialogCharacterType rightCharacter, bool rightSpeaks, string rightCharacterConfigId, bool waitConfirmation, CameraTargetName scrollToCameraTarget, bool waitForEndOfScrolling, CameraZoomTarget cameraZoomTarget, bool needsTransition, CameraTargetName moveToCameraTarget, List<HotspotId> scrollToHotSpot, HotspotId activateHotSpot, List<DialogLayoutEvent> layoutEvents, string animationGameObjectName, string animationTrackName, string animationSpineName, string animationFinalState, List<MetaRef<MapCharacterEventDefinition>> mapCharactersEvents, List<MapCharacterType> resetMapCharacters, List<DialogCharacterType> discoveredCharacters, bool disallowClose, List<IDirectorAction> startActions)
        {
        }
    }
}