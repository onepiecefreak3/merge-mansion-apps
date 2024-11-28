using GameLogic;
using Metaplay.Core.Model;

namespace Game.Cloud.Webshop
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum PurchasedProgressionEventTrackOption
    {
        Track1 = 0,
        Track2 = 1,
        Upgrade = 2
    }
}