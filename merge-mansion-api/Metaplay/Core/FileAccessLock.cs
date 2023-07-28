using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Metaplay.Core
{
    public struct FileAccessLock : IDisposable
    {
        // Fields
        private static readonly object s_lock = new(); // 0x0
        private static Dictionary<string, OngoingOp> s_ops; // 0x8

        private string _canonicalPath; // 0x0
        private SemaphoreSlim? _semaphore; // 0x8

        private FileAccessLock(string canonicalPath, SemaphoreSlim semaphore)
        {
            _canonicalPath = canonicalPath;
            _semaphore = semaphore;
        }

        public void Dispose()
        {
            if (_semaphore == null)
                return;

            _semaphore.Release();
            lock (s_lock)
            {
                if (s_ops == null)
                    return;

                if (!s_ops.TryGetValue(_canonicalPath, out var op) || op.Semaphore != _semaphore)
                    return;

                if (op.NumOngoing >= 2)
                    s_ops[_canonicalPath] = new OngoingOp(_semaphore, op.NumOngoing - 1);
                else
                {
                    s_ops.Remove(_canonicalPath);
                    if (s_ops.Count == 0)
                        s_ops = null;
                }
            }

            _semaphore = null;
        }

        public static async Task<FileAccessLock> AcquireAsync(string path)
        {
            var (canonicalPath, semaphore) = AllocateLock(path);
            await semaphore.WaitAsync();

            return new FileAccessLock(canonicalPath, semaphore);
        }

        public static FileAccessLock AcquireSync(string path)
        {
            var (canonicalPath, semaphore) = AllocateLock(path);
            semaphore.Wait();

            return new FileAccessLock(canonicalPath, semaphore);
        }

        private static (string, SemaphoreSlim) AllocateLock(string path)
        {
            path = FileUtil.NormalizePath(path);

            SemaphoreSlim newSemaphore;
            lock (s_lock)
            {
                s_ops ??= new Dictionary<string, OngoingOp>();
                if (!s_ops.TryGetValue(path, out var op))
                {
                    newSemaphore = new SemaphoreSlim(1);
                    s_ops.Add(path, new OngoingOp(newSemaphore, 1));
                }
                else
                {
                    newSemaphore = op.Semaphore;
                    s_ops[path] = new OngoingOp(newSemaphore, op.NumOngoing + 1);
                }
            }

            return (path, newSemaphore);
        }

        private static void FreeLock(string canonicalPath, SemaphoreSlim semaphore)
        {
            semaphore.Release();
            lock (s_lock)
            {
                if (s_ops == null)
                    return;

                if (!s_ops.TryGetValue(canonicalPath, out var op) || semaphore != op.Semaphore)
                    return;

                if (op.NumOngoing >= 2)
                    s_ops[canonicalPath] = new OngoingOp(semaphore, op.NumOngoing - 1);
                else
                {
                    s_ops.Remove(canonicalPath);
                    if (s_ops.Count == 0)
                        s_ops = null;
                }
            }
        }

        private struct OngoingOp
        {
            public SemaphoreSlim Semaphore; // 0x0
            public int NumOngoing; // 0x8

            public OngoingOp(SemaphoreSlim semaphore, int numOngoing)
            {
                Semaphore = semaphore;
                NumOngoing = numOngoing;
            }
        }
    }
}
