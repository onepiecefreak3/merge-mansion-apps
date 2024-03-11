using System.Collections.Generic;
using GameLogic.ConfigPrefabs;
using GameLogic.Player.Director.Config;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Metaplay.Core;
using System;

namespace GameLogic.Decorations
{
    [MetaSerializable]
    public class DecorationInfo : IGameConfigData<DecorationId>, IGameConfigData, IHasGameConfigKey<DecorationId>
    {
        [MetaMember(1, 0)]
        public DecorationId DecorationId { get; set; }

        [MetaMember(2, 0)]
        public string DisplayName { get; set; }

        [MetaMember(3, 0)]
        public string Description { get; set; }

        [MetaMember(4, 0)]
        public CameraTargetName CameraTargetName { get; set; }

        [MetaMember(5, 0)]
        public ConfigAssetPackId AssetPackId { get; set; }

        [MetaMember(6, 0)]
        public string NameLocId { get; set; }

        [MetaMember(7, 0)]
        public string DescLocId { get; set; }

        [MetaMember(8, 0)]
        private List<IDirectorAction> OnReceiveActions { get; set; }
        public DecorationId ConfigKey => DecorationId;
        public IEnumerable<IDirectorAction> OnReceive => OnReceiveActions;

        [MetaMember(9, (MetaMemberFlags)0)]
        private MetaRef<LayeredDecorationSetInfo> LayeredDecorationSetInfoRef { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public CameraZoomTarget CameraZoomTarget { get; set; }
        public LayeredDecorationSetInfo LayeredDecorationSetInfo { get; }

        public DecorationInfo()
        {
        }

        public DecorationInfo(DecorationId decorationId, string displayName, string description, CameraTargetName cameraTargetName, CameraZoomTarget cameraZoomTarget, ConfigAssetPackId assetPackId, string nameLocId, string descLocId, List<IDirectorAction> onReceiveActions, string layeredDecorationSetId)
        {
        }
    }
}