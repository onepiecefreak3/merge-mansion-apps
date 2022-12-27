using System;

namespace Metaplay.Metaplay.Network
{
	public interface IDownload : IDisposable 
    {
        DownloadStatus Status { get; }
    }
}
