using System;
using Integral.Aggregates;
using Integral.Constants;
using Integral.Diagnostics;
using Integral.Extensions;

namespace Integral.Collections
{
    internal sealed class ConsoleKeyInfoActionCollection : ConsoleKeyInfoActionAggregate
    {
        private readonly IndexedCollection<ConsoleKeyInfo, Action> actions = new IndexedCollection<ConsoleKeyInfo, Action>();

        private readonly IndexedCollection<ConsoleKeyInfo, Action<int>> intActions = new IndexedCollection<ConsoleKeyInfo, Action<int>>();

        private readonly IndexedCollection<ConsoleKeyInfo, Action<ConsoleKeyInfo>> consoleKeyInfoActions = new IndexedCollection<ConsoleKeyInfo, Action<ConsoleKeyInfo>>();

        public bool Add(ConsoleKeyInfo consoleKeyInfo, Action action) => actions.Add(consoleKeyInfo, action);

        public bool Add(ConsoleKeyInfo consoleKeyInfo, Action<int> action) => intActions.Add(consoleKeyInfo, action);

        public bool Add(ConsoleKeyInfo consoleKeyInfo, Action<ConsoleKeyInfo> action) => consoleKeyInfoActions.Add(consoleKeyInfo, action);

        internal void Execute(ConsoleKeyInfo consoleKeyInfo)
        {
            if (actions.TryGetValue(consoleKeyInfo, out Action? action))
            {
                action();
            }
            else if (intActions.TryGetValue(consoleKeyInfo, out Action<int>? intAction))
            {
                intAction(consoleKeyInfo.ToNumber());
            }
            else if (consoleKeyInfoActions.TryGetValue(consoleKeyInfo, out Action<ConsoleKeyInfo>? consoleKeyInfoAction))
            {
                consoleKeyInfoAction(consoleKeyInfo);
            }
            else
            {
                Log.Write(ConsoleConstant.InvalidCommand + consoleKeyInfo.ToFormattedString());
            }
        }
    }
}