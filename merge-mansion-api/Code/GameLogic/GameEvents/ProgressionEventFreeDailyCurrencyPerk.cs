using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(4)]
    public class ProgressionEventFreeDailyCurrencyPerk : ProgressionEventPerk
    {
        public ProgressionEventFreeDailyCurrencyPerk()
        {
        }

        public ProgressionEventFreeDailyCurrencyPerk(MetaDuration interval)
        {
        }
    }
}