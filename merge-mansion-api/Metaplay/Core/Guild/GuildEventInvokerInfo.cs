using Metaplay.Core.Model;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    public struct GuildEventInvokerInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GuildEventInvokerInfo.InvokerType Type { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public GuildEventMemberInfo Member { get; set; }

        [MetaSerializable]
        public enum InvokerType
        {
            Member = 0,
            Admin = 1
        }
    }
}