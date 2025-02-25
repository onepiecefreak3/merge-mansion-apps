using Metaplay.Core.Model;

namespace GameLogic.Config
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum OfferType
    {
        Undefined = 0,
        Generic = 1,
        BigBundle = 2,
        MakeYourOwn = 3
    }
}