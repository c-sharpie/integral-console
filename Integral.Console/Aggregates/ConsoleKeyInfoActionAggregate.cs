using System;

namespace Integral.Aggregates
{
    public interface ConsoleKeyInfoActionAggregate : PairedIncreasingAggregate<ConsoleKeyInfo, Action>,
                                                     PairedIncreasingAggregate<ConsoleKeyInfo, Action<int>>,
                                                     PairedIncreasingAggregate<ConsoleKeyInfo, Action<ConsoleKeyInfo>>

    {
    }
}