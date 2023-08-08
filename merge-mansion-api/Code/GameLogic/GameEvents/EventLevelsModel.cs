using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventLevelsModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Level;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Points;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int SeenLevel;
        [MetaMember(4, (MetaMemberFlags)0)]
        public int SeenPoints;
        [MetaMember(5, (MetaMemberFlags)0)]
        public int ConsumedLevel;
        public EventLevelsModel()
        {
        }
    }
}