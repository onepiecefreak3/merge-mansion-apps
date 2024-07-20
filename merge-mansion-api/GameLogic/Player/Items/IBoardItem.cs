using Metaplay.Core.Serialization;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    [MetaDeserializationConvertFromConcreteDerivedType(typeof(MergeItem))]
    public interface IBoardItem
    {
        int ItemId { get; }

        string ItemType { get; }
    }
}