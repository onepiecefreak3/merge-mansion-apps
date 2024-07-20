using Metaplay.Core.Model;

namespace Game.Cloud.Webshop
{
    [MetaSerializable]
    public enum WebShopLinkType
    {
        FromBackendMergeMansionSite = 0,
        FromBackendWebShopSite = 1,
        FromGameConfig = 2
    }
}