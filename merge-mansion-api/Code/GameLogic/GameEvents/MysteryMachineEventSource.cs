using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using Metaplay.Core.Offers;
using GameLogic.Story;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineEventSource : IConfigItemSource<MysteryMachineEventInfo, MysteryMachineEventId>, IGameConfigSourceItem<MysteryMachineEventId, MysteryMachineEventInfo>, IHasGameConfigKey<MysteryMachineEventId>
    {
        public MysteryMachineEventId ConfigKey { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private string NameLocId { get; set; }
        private MysteryMachineId MysteryMachineId { get; set; }
        private MetaRef<BoardInfo> Board { get; set; }
        private string PortalItem { get; set; }
        private OfferPlacementId BoardShopPlacementId { get; set; }
        private StoryDefinitionId EnterBoardDialogue { get; set; }
        private StoryDefinitionId StartMachineDialogue { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }

        public MysteryMachineEventSource()
        {
        }
    }
}