using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents.CardCollectionSupportingEvent
{
    [MetaSerializable]
    public struct EventLevelData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int LevelNumber;
    }
}