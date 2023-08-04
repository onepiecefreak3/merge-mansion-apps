using Metaplay.Core.Serialization;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items
{
    [MetaDeserializationConvertFromConcreteDerivedType(typeof(MergeItem))]
    [MetaSerializable]
    public interface IBoardItem
    {
        int ItemId { get; }

        string ItemType { get; }
    }
}