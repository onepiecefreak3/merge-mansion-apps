using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System.Collections.Generic;
using System;

namespace Metaplay.Core.League
{
    [MetaReservedMembers(100, 200)]
    public abstract class DivisionClientStateBase<TDivisionHistoryEntry> : PlayerSubClientStateBase, IDivisionClientState
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        [NoChecksum]
        public EntityId CurrentDivision { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public List<TDivisionHistoryEntry> HistoricalDivisions { get; set; }
        public DivisionIndex CurrentDivisionIndex { get; }
        public bool WasPromoted { get; }
        public bool WasDemoted { get; }

        IEnumerable<IDivisionHistoryEntry> Metaplay.Core.League.IDivisionClientState.HistoricalDivisions { get; }

        protected DivisionClientStateBase()
        {
        }

        [Transient]
        [NoChecksum]
        [MetaMember(102, (MetaMemberFlags)0)]
        public int CurrentDivisionParticipantIdx { get; set; }
    }
}