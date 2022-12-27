using System;

namespace Metaplay.Metaplay.Network
{
    public struct DownloadStatus
    {
        public StatusCode Code; // 0x0
        public Exception Error; // 0x8

        public DownloadStatus(StatusCode code, Exception error)
        {
            Code = code;
            Error = error;
        }

        public enum StatusCode
        {
            Initializing = 0,
            Downloading = 1,
            Error = 2,
            Timeout = 3,
            Cancelled = 4,
            Completed = 5
        }
    }
}
