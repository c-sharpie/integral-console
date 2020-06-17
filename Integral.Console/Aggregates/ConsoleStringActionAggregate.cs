using System;
using Integral.Structs;

namespace Integral.Aggregates
{
    public interface ConsoleStringActionAggregate : PairedIncreasingAggregate<ConsoleString, Action>,
                                                    PairedIncreasingAggregate<ConsoleString, Action<string>>,
                                                    PairedIncreasingAggregate<ConsoleString, Action<string[]>>
    {
    }
}