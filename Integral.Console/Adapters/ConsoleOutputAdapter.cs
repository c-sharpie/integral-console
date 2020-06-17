using System;

namespace Integral.Adapters
{
    public abstract class ConsoleOutputAdapter
    {
        protected ConsoleOutputAdapter()
        {
        }

        private void Update(object status) => Console.WriteLine(status);
    }
}
