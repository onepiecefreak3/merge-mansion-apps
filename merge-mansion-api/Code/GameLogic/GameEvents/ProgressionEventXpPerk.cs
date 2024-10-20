using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(5)]
    public class ProgressionEventXpPerk : ProgressionEventPerk
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        public ProgressionEventXpPerk()
        {
        }

        public ProgressionEventXpPerk(int amount)
        {
        }
    }
}