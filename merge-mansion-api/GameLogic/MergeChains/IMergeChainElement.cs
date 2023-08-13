using GameLogic.Player.Items;
using Metaplay.Core.Model;

namespace GameLogic.MergeChains
{
    [MetaSerializable]
    public interface IMergeChainElement
    {
        ItemDefinition First();
    }
}