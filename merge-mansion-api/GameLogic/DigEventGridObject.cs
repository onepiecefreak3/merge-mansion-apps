using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Code.GameLogic.GameEvents;

namespace GameLogic
{
    [MetaSerializable]
    public class DigEventGridObject
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int objectId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public string treasureName;
        [MetaMember(3, (MetaMemberFlags)0)]
        public bool isCollected;
        [MetaMember(4, (MetaMemberFlags)0)]
        public int rotation;
        [MetaMember(5, (MetaMemberFlags)0)]
        public bool isShiny;
        [MetaMember(6, (MetaMemberFlags)0)]
        public List<DigEventGridCell> occupiedCells;
        public DigEventGridObject()
        {
        }

        public DigEventGridObject(int id)
        {
        }

        public DigEventGridObject(DigEvent digEvent)
        {
        }
    }
}