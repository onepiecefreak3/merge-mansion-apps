using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System;
using System.Collections.Generic;
using GameLogic.Player.Board;
using GameLogic.Player.Items;
using GameLogic.EventCharacters;
using System.Runtime.Serialization;
using Metaplay.Core.Offers;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(11)]
    public class SideBoardEventModel : ExtendableEventState<SideBoardEventId, SideBoardEventInfo>, IBoardEventModel, IGroupIdGetter
    {
        public static int InitialLevel;
        private static int InitialLevelProgress;
        private static byte InitialBoolFields;
        private static int InitialEnterMergeBoardCount;
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override SideBoardEventId ActivableId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Level { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int LevelProgress { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<SideBoardEventClaimedLevelData> ClaimedLevels { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MergeBoard MergeBoard { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        protected byte BoolFields { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<IBoardItem> PocketItems { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public int EnterMergeBoardCount { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<EventTaskId> AvailableTaskIds { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<EventTaskId> CompletedTasksIds { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        protected byte BoolFields2 { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        private bool NotedNoResourceItem { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        private EventCharacterId LastNotedEndPopupUnlockedEventCharacterId { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        private EventCharacterId LastNotedProgressionPopupUnlockedEventCharacterId { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        private bool SkippingCompleteActions { get; set; }
        public bool PortalItemGiven { get; set; }
        public bool PreviewNoted { get; set; }
        public bool StartNoted { get; set; }
        public bool EndNoted { get; set; }
        public bool EnterBoardDialogueTriggered { get; set; }
        public bool EndOfEventLevelsClaimed { get; set; }
        public bool EndDialogueTriggered { get; set; }
        public bool ActiveDecorationNoted { get; set; }
        public bool IsPlayable { get; set; }

        [IgnoreDataMember]
        public bool RequestExtension { get; set; }
        public bool CanBeResolved { get; set; }
        public bool FtueNoted { get; set; }

        [IgnoreDataMember]
        public SideBoardEventInfo Info { get; }

        [IgnoreDataMember]
        public IBoardEventInfo BoardEventInfo { get; }

        [IgnoreDataMember]
        public override ExtendableEventParams ExtendableEventParams { get; }

        [IgnoreDataMember]
        MetaActivableState.Activation? Code.GameLogic.GameEvents.IBoardEventModel.LatestActivation { get; }

        [IgnoreDataMember]
        bool Code.GameLogic.GameEvents.IBoardEventModel.RequestExtension { get; set; }

        [IgnoreDataMember]
        OfferPlacementId Code.GameLogic.GameEvents.IBoardEventModel.BoardShopPlacementId { get; }

        [IgnoreDataMember]
        OfferPlacementId Code.GameLogic.GameEvents.IBoardEventModel.BoardShopFlashPlacementId { get; }
        public IStringId Id { get; }

        public SideBoardEventModel()
        {
        }

        public SideBoardEventModel(SideBoardEventInfo info)
        {
        }
    }
}