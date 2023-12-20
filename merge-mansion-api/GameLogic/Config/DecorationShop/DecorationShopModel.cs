using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace GameLogic.Config.DecorationShop
{
    [MetaSerializableDerived(10)]
    public class DecorationShopModel : MetaActivableState<DecorationShopId, DecorationShopInfo>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override DecorationShopId ActivableId { get; set; }

        private DecorationShopModel()
        {
        }

        public DecorationShopModel(DecorationShopInfo info)
        {
        }
    }
}