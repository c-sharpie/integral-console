using Integral.Constants;

namespace Integral.Structs
{
    public struct ConsoleString
    {
        private readonly string value;

        public ConsoleString(string value)
        {
            this.value = value;

            int index = value.IndexOf(CharConstant.StandardSeparator);
            Command = index >= 0 ? value.Substring(0, index) : value.TrimEnd();
            Argument = index >= 0 ? value.Substring(index + 1) : string.Empty;
            ArgumentArray = Argument.Split(CharConstant.StandardSeparator);
        }

        internal string Command { get; }

        internal string Argument { get; }

        internal string[] ArgumentArray { get; }

        public override string ToString() => value;

        public override int GetHashCode() => Command.GetHashCode();

        public override bool Equals(object? other) => other is ConsoleString consoleString && Command.Equals(consoleString.Command);
    }
}