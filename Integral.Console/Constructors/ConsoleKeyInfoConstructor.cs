using System;
using System.Linq;
using Integral.Enumerations;

namespace Integral.Constructors
{
    public static class ConsoleKeyInfoConstructor
    {
        public static ConsoleKeyInfo Create(ConsoleKey consoleKey, KeyModifier keyModifier = KeyModifier.None)
        {
            if (NullCharacterKeys.Contains(consoleKey))
            {
                return Create('\0', consoleKey, keyModifier);
            }

            return Create(Convert.ToChar(consoleKey), consoleKey, keyModifier);
        }

        public static ConsoleKeyInfo Create(char character, ConsoleKey consoleKey, KeyModifier keyModifier = KeyModifier.None)
        {
            bool shift = keyModifier.HasFlag(KeyModifier.Shift);
            bool alt = keyModifier.HasFlag(KeyModifier.Alt);
            bool control = keyModifier.HasFlag(KeyModifier.Control);
            return new ConsoleKeyInfo(character, consoleKey, shift, alt, control);
        }

        private static readonly ConsoleKey[] NullCharacterKeys =
        {
            ConsoleKey.F1,
            ConsoleKey.F2,
            ConsoleKey.F2,
            ConsoleKey.F3,
            ConsoleKey.F4,
            ConsoleKey.F5,
            ConsoleKey.F6,
            ConsoleKey.F7,
            ConsoleKey.F8,
            ConsoleKey.F9,
            ConsoleKey.F10,
            ConsoleKey.F11,
            ConsoleKey.F12
        };
    }
}