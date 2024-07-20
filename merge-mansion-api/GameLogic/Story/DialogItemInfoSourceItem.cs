using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config.Map.Characters;

namespace GameLogic.Story
{
    public class DialogItemInfoSourceItem : IConfigItemSource<DialogItemInfo, DialogItemId>, IGameConfigSourceItem<DialogItemId, DialogItemInfo>, IHasGameConfigKey<DialogItemId>
    {
        private DialogItemId DialogItemId { get; set; }
        private string LocalizationId { get; set; }
        private DialogMode DialogMode { get; set; }
        private DialogCharacterState LeftCharacterState { get; set; }
        private DialogCharacterType LeftCharacter { get; set; }
        private bool LeftSpeaks { get; set; }
        private string LeftCharacterConfigId { get; set; }
        private DialogCharacterState RightCharacterState { get; set; }
        private DialogCharacterType RightCharacter { get; set; }
        private bool RightSpeaks { get; set; }
        private string RightCharacterConfigId { get; set; }
        private bool WaitConfirmation { get; set; }
        private CameraTargetName ScrollToCameraTarget { get; set; }
        private bool WaitForEndOfScrolling { get; set; }
        private CameraZoomTarget CameraZoomTarget { get; set; }
        private bool NeedsTransition { get; set; }
        private CameraTargetName MoveToCameraTarget { get; set; }
        private List<HotspotId> ScrollToHotSpot { get; set; }
        private HotspotId ActivateHotSpot { get; set; }
        private List<DialogLayoutEvent> LayoutEvents { get; set; }
        private string AnimationGameObjectName { get; set; }
        private string AnimationTrackName { get; set; }
        private string AnimationSpineName { get; set; }
        private string AnimationFinalState { get; set; }
        private List<MetaRef<MapCharacterEventDefinition>> MapCharacterEvents { get; set; }
        private List<MapCharacterType> ResetMapCharacters { get; set; }
        private List<DialogCharacterType> DiscoveredCharacters { get; set; }
        private bool DisallowClose { get; set; }
        private List<string> StartAction { get; set; }
        public DialogItemId ConfigKey { get; }

        public DialogItemInfoSourceItem()
        {
        }
    }
}