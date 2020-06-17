using System;
using Integral.Aggregates;
using Integral.Structs;

namespace Integral.Adapters
{
    public abstract class ConsoleStringInputAdapter
    {
        protected ConsoleStringInputAdapter(ConsoleStringActionAggregate consoleStringActionAggregate)
        {
            consoleStringActionAggregate.Add(new ConsoleString("chat"), Chat);
            consoleStringActionAggregate.Add(new ConsoleString("who"), Who);
            consoleStringActionAggregate.Add(new ConsoleString("friend"), Friend);
            consoleStringActionAggregate.Add(new ConsoleString("block"), Block);
            consoleStringActionAggregate.Add(new ConsoleString("invite"), Invite);
            consoleStringActionAggregate.Add(new ConsoleString("leave"), Leave);
            consoleStringActionAggregate.Add(new ConsoleString("group"), Group);
        }

        private void Chat(string argument) => Console.WriteLine("This command is not implemented yet.");

        private void Who(string argument) => Console.WriteLine("This command is not implemented yet.");

        private void Friend(string argument) => Console.WriteLine("This command is not implemented yet.");

        private void Block(string argument) => Console.WriteLine("This command is not implemented yet.");

        private void Invite(string argument) => Console.WriteLine("This command is not implemented yet.");

        private void Leave() => Console.WriteLine("This command is not implemented yet.");

        private void Group() => Console.WriteLine("This command is not implemented yet.");
    }
}