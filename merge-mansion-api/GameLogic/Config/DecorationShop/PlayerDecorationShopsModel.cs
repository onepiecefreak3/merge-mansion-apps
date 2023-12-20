using Metaplay.Core.Activables;
using Metaplay.Core.Model;

namespace GameLogic.Config.DecorationShop
{
    [MetaActivableSet("DecorationShop", false)]
    [MetaSerializableDerived(10)]
    public class PlayerDecorationShopsModel : MetaActivableSet<DecorationShopId, DecorationShopInfo, DecorationShopModel>
    {
        public PlayerDecorationShopsModel()
        {
        }
    }
}