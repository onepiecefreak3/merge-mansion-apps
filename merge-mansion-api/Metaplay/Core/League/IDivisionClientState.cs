using System.Collections.Generic;

namespace Metaplay.Core.League
{
    public interface IDivisionClientState
    {
        EntityId CurrentDivision { get; set; }

        IEnumerable<IDivisionHistoryEntry> HistoricalDivisions { get; }
    }
}