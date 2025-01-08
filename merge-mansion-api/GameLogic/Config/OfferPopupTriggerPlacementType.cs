using Metaplay.Core.Model;

namespace GameLogic.Config
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
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