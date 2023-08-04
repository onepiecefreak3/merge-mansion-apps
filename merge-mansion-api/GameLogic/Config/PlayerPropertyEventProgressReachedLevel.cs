using GameLogic.Merge;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using Merge;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1006)]
    [MetaSerializable]
    public class PlayerPropertyEventProgressReachedLevel : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        public MergeBoardId MergeBoardId; // 0x10
        public override string DisplayName { get; }

        public PlayerPropertyEventProgressReachedLevel()
        {
        }

        public PlayerPropertyEventProgressReachedLevel(MergeBoardId mergeBoardId)
        {
        }
    }
}