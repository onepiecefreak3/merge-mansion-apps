using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.TieredOffers;

[MetaSerializable]
public class TieredOfferGroup : IGameConfigData<TieredOfferGroupId>, IGameConfigData
{
    [MetaMember(1, (MetaMemberFlags)0)]
    public TieredOfferGroupId ConfigKey { get; set; }

    public TieredOfferGroup()
    {
    }
}