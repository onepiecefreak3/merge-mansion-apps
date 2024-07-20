using Metaplay.Core.Activables;
using Metaplay.Core.Model;

namespace GameLogic.Config.DecorationShop
{
    [MetaSerializableDerived(10)]
    [MetaActivableSet("DecorationShop", false)]
    public class PlayerDecorationShopsModel : MetaActivableSet<DecorationShopId, DecorationShopInfo, DecorationShopModel>
    {
        public PlayerDecorationShopsModel()
        {
        }
    }
}