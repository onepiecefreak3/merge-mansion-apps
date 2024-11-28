using Metaplay.Core.Model;

namespace GameLogic.Player.Items
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum PortalPieceChainAnalyticsType
    {
        AcquiredPortalPiece = 0,
        CompletedPortal = 1
    }
}