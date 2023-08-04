using System;

namespace GameLogic.Mail
{
    public interface IBroadcastMailMessage
    {
        int BroadcastId { get; }

        bool TrackImpressions { get; }
    }
}