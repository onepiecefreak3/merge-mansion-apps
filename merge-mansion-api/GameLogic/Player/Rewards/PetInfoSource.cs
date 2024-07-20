using Code.GameLogic.Config;
using Metaplay.Core.Config;
using GameLogic.Cutscenes;
using GameLogic.ConfigPrefabs;
using System;
using GameLogic.Decorations;
using GameLogic.Config.Map.Characters;

namespace GameLogic.Player.Rewards
{
    public class PetInfoSource : IConfigItemSource<PetInfo, PetId>, IGameConfigSourceItem<PetId, PetInfo>, IHasGameConfigKey<PetId>
    {
        public PetId ConfigKey { get; set; }
        private CutsceneId OnDiscoveredCutscene { get; set; }
        private ConfigAssetPackId AssetPackId { get; set; }
        private string UnlockHeaderLocId { get; set; }
        private string UnlockDescLocId { get; set; }
        private string InfoHeaderLocId { get; set; }
        private string InfoDescLocId { get; set; }
        private DecorationId Decoration { get; set; }
        private string SelectionHeaderLocId { get; set; }
        private string SelectionDescriptionLocId { get; set; }
        private MapCharacterPositionId PetHomeCharacterPositionId { get; set; }

        public PetInfoSource()
        {
        }
    }
}