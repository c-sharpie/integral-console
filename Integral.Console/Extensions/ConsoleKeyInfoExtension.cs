using System;

namespace Integral.Extensions
{
    public static class ConsoleKeyInfoExtension
    {
        public static string ToFormattedString(this ConsoleKeyInfo consoleKeyInfo)
        {
            if (consoleKeyInfo.Modifiers > 0)
            {
                return $"{consoleKeyInfo.Modifiers} + {consoleKeyInfo.Key}";
            }

            return consoleKeyInfo.Key.ToString();
        }

        internal static int ToNumber(this ConsoleKeyInfo consoleKeyInfo) => Array.IndexOf(Numbers, consoleKeyInfo.Key);

        private static readonly ConsoleKey[] Numbers =
        {
            ConsoleKey.D0,
            ConsoleKey.D1,
            ConsoleKey.D2,
            ConsoleKey.D3,
            ConsoleKey.D4,
            ConsoleKey.D5,
            ConsoleKey.D6,
            ConsoleKey.D7,
            ConsoleKey.D8,
            ConsoleKey.D9
        };
    }
}