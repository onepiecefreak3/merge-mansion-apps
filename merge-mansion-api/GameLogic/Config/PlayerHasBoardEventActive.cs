using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using Merge;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1019)]
    public class PlayerHasBoardEventActive : TypedPlayerPropertyId<bool>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MergeBoardId RequiredBoardEvent { get; set; }
        public override string DisplayName { get; }

        public PlayerHasBoardEventActive()
        {
        }

        public PlayerHasBoardEventActive(MergeBoardId requiredBoardEvent)
        {
        }
    }
}