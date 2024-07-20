using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using GameLogic.ConfigPrefabs;
using System.Collections.Generic;
using GameLogic.Cutscenes;

namespace GameLogic.Decorations
{
    public class DecorationInfoSource : IConfigItemSource<DecorationInfo, DecorationId>, IGameConfigSourceItem<DecorationId, DecorationInfo>, IHasGameConfigKey<DecorationId>
    {
        public DecorationId DecorationId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public CameraTargetName CameraTargetName { get; set; }
        public CameraZoomTarget CameraZoomTarget { get; set; }
        public ConfigAssetPackId AssetPackId { get; set; }
        public string NameLocId { get; set; }
        public string DescLocId { get; set; }
        public List<string> OnReceiveActions { get; set; }
        public string LayeredDecorationSetId { get; set; }
        private CutsceneId OnClaimedCutscene { get; set; }
        public DecorationId ConfigKey { get; }

        public DecorationInfoSource()
        {
        }
    }
}