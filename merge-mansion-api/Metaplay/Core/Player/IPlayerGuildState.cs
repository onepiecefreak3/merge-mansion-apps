using Metaplay.Core.Guild;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Player
{
    public interface IPlayerGuildState
    {
        EntityId GuildId { get; set; }

        GuildCreationParamsBase PendingGuildCreation { get; set; }

        int LastPendingGuildOpEpoch { get; set; }

        Dictionary<int, GuildMemberGuildOpLogEntry> PendingGuildOps { get; set; }

        int LastPlayerOpEpoch { get; set; }

        int GuildMemberInstanceId { get; set; }
    }
}