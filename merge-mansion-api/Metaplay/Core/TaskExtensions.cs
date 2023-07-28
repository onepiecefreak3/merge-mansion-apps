using System;
using System.Threading.Tasks;

namespace Metaplay.Core
{
    public static class TaskExtensions
    {
        public static void ContinueWithDispose<TResult>(this Task<TResult> task, bool allowSynchronousExecution = true)
            where TResult : IDisposable
        {
            if (allowSynchronousExecution)
            {
                if (task.Status == TaskStatus.Faulted)
                    return; //throw task.Exception;

                if (task.Status == TaskStatus.RanToCompletion)
                    task.Result?.Dispose();

                return;
            }

            task.Result?.Dispose();
        }
    }
}
