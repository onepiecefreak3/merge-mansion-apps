using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Config;
using Metaplay.GameLogic.ConfigPrefabs;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.GameLogic.Story;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Activables;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Offers;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class BoardEventInfo: IGameConfigData<EventId>
    {
		[MetaMember(1, 0)]
		public EventId EventId { get; set; }
		[MetaMember(2, 0)]
		public string DisplayName { get; set; }
		[MetaMember(3, 0)]
		public string Description { get; set; }
		[MetaMember(4, 0)]
		public MetaActivableParams ActivableParams { get; set; }
		[MetaMember(5, 0)]
		public MetaRef<EventCurrencyInfo> EventCurrencyInfo { get; set; }
		[MetaMember(6, 0)]
		public MetaRef<BoardInfo> BoardInfo { get; set; }
		[MetaMember(7, 0)]
		public MetaRef<EventTaskInfo> EventInitTask { get; set; }
		[MetaMember(8, 0)]
		public List<MetaRef<EventTaskInfo>> EventTasks { get; set; }
		[MetaMember(9, 0)]
		public MetaRef<EventLevels> Levels { get; set; }
		[MetaMember(12, 0)]
		public ItemTypeConstant? PortalItem { get; set; }
		[MetaMember(15, 0)]
		public string NameLocalizationId { get; set; }
		[MetaMember(16, 0)]
		public string DescLocalizationId { get; set; }
		[MetaMember(17, 0)]
		public OfferPlacementId BoardShopPlacementId { get; set; }
		[MetaMember(18, 0)]
		public ExtendableEventParams ExtendableEventParams { get; set; }
		[MetaMember(19, 0)]
		public MetaRef<InAppProductInfo> ExtensionInAppProduct { get; set; }
		[MetaMember(20, 0)]
		public MetaDuration ExtensionPurchaseSafetyMargin { get; set; }
		[MetaMember(21, 0)]
		public ConfigPrefabId InfoPopupId { get; set; }
		[MetaMember(22, 0)]
		public ConfigPrefabId TaskProgressionId { get; set; }
		[MetaMember(23, 0)]
		public ConfigPrefabId TaskGoalItemId { get; set; }
		[MetaMember(24, 0)]
		public MetaRef<ShopEventInfo> HintedShopEvent { get; set; }
		[MetaMember(25, 0)]
		public StoryDefinitionId StartEventDialogue { get; set; }
		[MetaMember(26, 0)]
		public ConfigPrefabId StartPopupId { get; set; }
		[MetaMember(27, 0)]
		public ConfigPrefabId TeasePopupId { get; set; }
		[MetaMember(28, 0)]
		public ConfigPrefabId IntroPopupId { get; set; }
		[MetaMember(29, 0)]
		public ConfigPrefabId ExtendPopupId { get; set; }
		[MetaMember(30, 0)]
		public ConfigPrefabId EndPopupId { get; set; }
		[MetaMember(31, 0)]
		public ConfigPrefabId HudButtonId { get; set; }
		[MetaMember(32, 0)]
		public ConfigPrefabId RewardInfoPopupId { get; set; }
		[MetaMember(33, 0)]
		public ConfigPrefabId RewardClaimPopupId { get; set; }
		[MetaMember(34, 0)]
		public ConfigPrefabId RewardChestPopupId { get; set; }
		[MetaMember(35, 0)]
		public bool VisualiseEventPoints { get; set; }
		[MetaMember(36, 0)]
		public ConfigPrefabId TaskItemCheckmarkId { get; set; }
		[MetaMember(37, 0)]
		private List<IDirectorAction> StartActions { get; set; }
		[MetaMember(38, 0)]
		private List<IDirectorAction> EndActions { get; set; }

        public EventId ConfigKey => EventId;

        public IEnumerable<IDirectorAction> OnStart => StartActions;
        public IEnumerable<IDirectorAction> OnEnd => EndActions;
    }
}
