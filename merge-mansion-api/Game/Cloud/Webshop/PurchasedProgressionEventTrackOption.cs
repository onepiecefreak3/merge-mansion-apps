using GameLogic;
using Metaplay.Core.Model;

namespace Game.Cloud.Webshop
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum PurchasedProgressionEventTrackOption
    {
        Track1 = 0,
        Track2 = 1,
        Upgrade = 2
    }
}