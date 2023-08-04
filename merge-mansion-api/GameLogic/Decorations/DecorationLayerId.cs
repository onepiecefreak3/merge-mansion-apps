using Metaplay.Core.Model;

namespace GameLogic.Decorations
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum DecorationLayerId
    {
        None = 0,
        LDEPC2023RemoveFoliageTA1 = 1,
        LDEPC2023RemoveFoodTruckRustTA2 = 2,
        LDEPC2023PlaceCounterTA3 = 3,
        LDEPC2023PlaceRugsTA4 = 4,
        LDEPC2023PlaceRestaurantSignTA5 = 5,
        LDEPC2023PlaceStoolsTA6 = 6,
        LDEPC2023PlaceFoodTA7 = 7,
        LDEPC2023PlaceMarqueeTB1 = 8,
        LDEPC2023PlaceTablesTB2 = 9,
        LDEPC2023PlaceFlowersTB3 = 10,
        LDEPC2023PlacePartyFlagsTB4 = 11,
        LDEPC2023PlaceTrailerTB5 = 12,
        LDEPC2023PlaceHangingLightsTC1 = 13,
        LDEPC2023PlacePaintDecalsTC2 = 14,
        LDEPC2023PlaceRooftopOrnamentsTC3 = 15
    }
}