using System;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Network
{
    public sealed class DownloadTaskWrapper<TResult> : IDownload
    {
        private readonly object _lock; // 0x10
        private Task<TResult> _task; // 0x18
        private Exception _lockedException; // 0x20
        private bool _lockedTimeout; // 0x28

        public DownloadStatus Status => GetStatus();

        public DownloadTaskWrapper()
        { }

        public DownloadTaskWrapper(Task<TResult> task)
        {
            _lock = new object();
            _task = task ?? throw new ArgumentNullException(nameof(task));
        }

        public TResult GetResult()
        {
            return _task.Result;
        }

        private DownloadStatus GetStatus()
        {
            lock (_lock)
            {
                if (_lockedException != null)
                    return new DownloadStatus(DownloadStatus.StatusCode.Error, _lockedException);

                if (_lockedTimeout)
                    return new DownloadStatus(DownloadStatus.StatusCode.Timeout, null);

                var status = _task.Status;
                if (status == TaskStatus.RanToCompletion)
                    return new DownloadStatus(DownloadStatus.StatusCode.Completed, null);

                if (status == TaskStatus.Canceled)
                    return new DownloadStatus(DownloadStatus.StatusCode.Cancelled, null);

                if (status != TaskStatus.Faulted)
                    return new DownloadStatus(DownloadStatus.StatusCode.Downloading, null);

                if (_task.Exception == null)
                    return new DownloadStatus(DownloadStatus.StatusCode.Completed, null);

                if (_task.Exception.InnerExceptions[0] is TimeoutException toe)
                {
                    _lockedTimeout = true;
                    return new DownloadStatus(DownloadStatus.StatusCode.Timeout, null);
                }

                _lockedException = _task.Exception;
                return new DownloadStatus(DownloadStatus.StatusCode.Error, _task.Exception);
            }
        }

        public void Dispose()
        {
            lock (_lock)
            {
                if (_task == null)
                    return;

                var status = _task.Status;
                if (status == TaskStatus.RanToCompletion)
                    _task.Dispose();

                _task = null;
            }
        }
    }
}
