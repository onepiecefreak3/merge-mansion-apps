using GameLogic.Player.Items;
using Metaplay.Core.Model;

namespace GameLogic.MergeChains
{
    [MetaSerializable]
    public interface IMergeChainElement
    {
        // RVA: -1 Offset: -1 Slot: 0
        int IndexOf(int itemId);
        // RVA: -1 Offset: -1 Slot: 1
        bool Contains(int itemId);
        // RVA: -1 Offset: -1 Slot: 2
        ItemDefinition First();
        // RVA: -1 Offset: -1 Slot: 4
        ItemDefinition ElementAtOrDefault(int index);
    }
}