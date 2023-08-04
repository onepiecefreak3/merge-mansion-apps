using Metaplay.Core;
using System;
using Merge;

namespace GameLogic.Player
{
    public class PocketChangedEvent : CopyableEvent<PocketChangedEvent, int, MergeBoardId, int, PlayerPocketChangeEventType?>
    {
        public PocketChangedEvent()
        {
        }
    }
}