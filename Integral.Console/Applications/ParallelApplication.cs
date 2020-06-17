using System;
using System.Threading;
using System.Threading.Tasks;
using Integral.Abstractions;
using Integral.Actions;
using Integral.Diagnostics;

namespace Integral.Applications
{
    public abstract class ParallelApplication : ConsoleApplication
    {
        protected CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

        protected ParallelApplication() => TaskScheduler.UnobservedTaskException += UnhandledException;

        protected void Execute(Executable<Task> executable) => Execute(executable.Execute);

        protected void Execute(AsyncAction asyncAction) => asyncAction(CancellationTokenSource.Token).ContinueWith(Complete, CancellationTokenSource.Token);

        private void UnhandledException(object? sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            if (unobservedTaskExceptionEventArgs.Exception != null)
            {
                Log.Write(unobservedTaskExceptionEventArgs.Exception);
            }

            if (!unobservedTaskExceptionEventArgs.Observed)
            {
                unobservedTaskExceptionEventArgs.SetObserved();
            }
        }

        private void Complete(Task task)
        {
            try
            {
                task.Wait();
            }
            catch (Exception exception)
            {
                Log.Write(exception);
                CancellationTokenSource.Cancel();
                Console.WriteLine("Press any key to exit the application.");
            }
        }
    }
}