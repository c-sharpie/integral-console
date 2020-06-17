using System;
using Integral.Abstractions;
using Integral.Diagnostics;

namespace Integral.Applications
{
    public abstract class ConsoleApplication : Application, Executable
    {
        protected ConsoleApplication()
        {
            AppDomain.CurrentDomain.UnhandledException += Handle;
            Log.OnWriteInformation += Console.WriteLine;
            Log.OnWriteException += Console.WriteLine;
        }

        public abstract void Execute();

        private void Handle(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            Log.Write((Exception)unhandledExceptionEventArgs.ExceptionObject);
            if (unhandledExceptionEventArgs.IsTerminating)
            {
                Console.ReadLine();
            }
        }
    }
}