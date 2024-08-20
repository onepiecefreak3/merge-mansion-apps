using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace GameLogic.MiniEvents
{
    [MetaSerializable]
    public class MiniEventVariantInfo : IGameConfigData<MiniEventId>, IGameConfigData, IHasGameConfigKey<MiniEventId>
    {
        public MiniEventId ConfigKey { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        private MiniEventId MiniEventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string VariantId { get; set; }

        public MiniEventVariantInfo()
        {
        }

        public MiniEventVariantInfo(MiniEventId miniEventId, string variantId)
        {
        }
    }
}