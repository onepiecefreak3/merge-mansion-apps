using System.Collections.Generic;
using GameLogic.Player.Items;
using GameLogic.Player.Board;
using System;
using Metaplay.Core.Activables;

namespace Code.GameLogic.GameEvents
{
    public interface IBoardEventModel
    {
        IBoardEventInfo EventInfo { get; }

        List<IBoardItem> PocketItems { get; }

        MergeBoard MergeBoard { get; }

        int EnterMergeBoardCount { get; set; }

        bool EnterBoardDialogueTriggered { get; set; }

        MetaActivableState.Activation? LatestActivation { get; }

        bool RequestExtension { get; set; }
    }
}