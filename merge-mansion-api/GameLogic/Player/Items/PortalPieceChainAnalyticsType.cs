using Metaplay.Core.Model;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum PortalPieceChainAnalyticsType
    {
        AcquiredPortalPiece = 0,
        CompletedPortal = 1
    }
}