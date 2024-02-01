using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class EventTaskLocEntry
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventTaskId EventTaskId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string LocId { get; set; }

        public EventTaskLocEntry()
        {
        }

        public EventTaskLocEntry(EventTaskId eventTaskId, string locId)
        {
        }
    }
}