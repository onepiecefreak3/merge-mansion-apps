using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventTreasureItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string TreasureName;
        [MetaMember(2, (MetaMemberFlags)0)]
        public List<ValueTuple<int, int>> Shape;
        [MetaMember(3, (MetaMemberFlags)0)]
        public F32 Weight;
        [MetaMember(4, (MetaMemberFlags)0)]
        public bool IsShiny;
        [MetaMember(5, (MetaMemberFlags)0)]
        public string AssetId;
        public DigEventTreasureItem()
        {
        }

        public DigEventTreasureItem(string treasureName, List<ValueTuple<int, int>> shape, F32 weight, string assetId, bool isShiny)
        {
        }
    }
}