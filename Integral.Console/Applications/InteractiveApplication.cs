using System;
using Integral.Aggregates;
using Integral.Collections;
using Integral.Structs;

namespace Integral.Applications
{
    public abstract class InteractiveApplication : ParallelApplication
    {
        private readonly ConsoleKeyInfoActionCollection consoleKeyInfoActionCollection = new ConsoleKeyInfoActionCollection();

        private readonly ConsoleStringActionCollection consoleStringActionCollection = new ConsoleStringActionCollection();

        protected ConsoleKeyInfoActionAggregate ConsoleKeyInfoActionAggregate => consoleKeyInfoActionCollection;

        protected ConsoleStringActionAggregate ConsoleStringActionAggregate => consoleStringActionCollection;

        public override void Execute()
        {
            // TODO: Change input aggregates to concurrent queues for thread safety.
            while (!CancellationTokenSource.IsCancellationRequested)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                if (!CancellationTokenSource.IsCancellationRequested)
                {
                    switch (consoleKeyInfo.Key)
                    {
                        case ConsoleKey.Escape:
                            CancellationTokenSource.Cancel();
                            break;
                        case ConsoleKey.Delete:
                            Console.Clear();
                            break;
                        case ConsoleKey.Oem2:
                            Console.Write(consoleKeyInfo.KeyChar);
                            consoleStringActionCollection.Execute(new ConsoleString(Console.ReadLine() ?? string.Empty));
                            break;
                        default:
                            consoleKeyInfoActionCollection.Execute(consoleKeyInfo);
                            break;
                    }
                }
            }
        }
    }
}