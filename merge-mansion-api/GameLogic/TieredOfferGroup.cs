using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.TieredOffers;

namespace GameLogic
{
    [MetaSerializable]
    public class TieredOfferGroup : IGameConfigData<TieredOfferGroupId>, IGameConfigData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public TieredOfferGroupId ConfigKey { get; set; }

        public TieredOfferGroup()
        {
        }
    }
}