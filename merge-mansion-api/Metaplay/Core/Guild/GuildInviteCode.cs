using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace Metaplay.Core.Guild
{
    [JsonConverter(typeof(GuildInviteCodeConverter))]
    [MetaSerializable]
    public struct GuildInviteCode
    {
        public static ulong MaxRawValue;
        [MetaMember(1, (MetaMemberFlags)0)]
        public ulong Raw { get; set; }
    }
}