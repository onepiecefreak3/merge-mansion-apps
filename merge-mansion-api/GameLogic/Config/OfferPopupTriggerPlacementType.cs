using Metaplay.Core.Model;

namespace GameLogic.Config
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum OfferPopupTriggerPlacementType
    {
        None = 0,
        GameOpen = 1,
        LobbyReturn = 2,
        MergeBoardEnter = 3,
        PopupOpen = 4,
        PopupClose = 5
    }
}