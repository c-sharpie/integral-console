using System;
using Integral.Aggregates;
using Integral.Constants;
using Integral.Diagnostics;
using Integral.Structs;

namespace Integral.Collections
{
    internal sealed class ConsoleStringActionCollection : ConsoleStringActionAggregate
    {
        private readonly IndexedCollection<ConsoleString, Action> actions = new IndexedCollection<ConsoleString, Action>();

        private readonly IndexedCollection<ConsoleString, Action<string>> stringActions = new IndexedCollection<ConsoleString, Action<string>>();

        private readonly IndexedCollection<ConsoleString, Action<string[]>> stringArrayActions = new IndexedCollection<ConsoleString, Action<string[]>>();

        public bool Add(ConsoleString consoleString, Action action) => actions.Add(consoleString, action);

        public bool Add(ConsoleString consoleString, Action<string> action) => stringActions.Add(consoleString, action);

        public bool Add(ConsoleString consoleString, Action<string[]> action) => stringArrayActions.Add(consoleString, action);

        internal void Execute(ConsoleString consoleString)
        {
            if (actions.TryGetValue(consoleString, out Action? action))
            {
                action();
            }
            else if (stringActions.TryGetValue(consoleString, out Action<string>? stringAction))
            {
                stringAction(consoleString.Argument);
            }
            else if (stringArrayActions.TryGetValue(consoleString, out Action<string[]>? stringArrayAction))
            {
                stringArrayAction(consoleString.ArgumentArray);
            }
            else if (!string.IsNullOrWhiteSpace(consoleString.Command))
            {
                Log.Write(ConsoleConstant.InvalidCommand + consoleString);
            }
        }
    }
}