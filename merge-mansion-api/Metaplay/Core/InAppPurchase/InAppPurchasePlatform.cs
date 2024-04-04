using Metaplay.Core.Model;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public enum InAppPurchasePlatform
    {
        Google = 0,
        Apple = 1,
        Development = 2,
        _ReservedDontUse3 = 3,
        WebshopNeon = 100
    }
}