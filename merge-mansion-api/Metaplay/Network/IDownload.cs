using System;

namespace Metaplay.Network
{
	public interface IDownload : IDisposable 
    {
        DownloadStatus Status { get; }
    }
}
