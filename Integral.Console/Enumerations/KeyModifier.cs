using System;

namespace Integral.Enumerations
{
    [Flags]
    public enum KeyModifier : byte
    {
        None = 0,
        Shift = 1,
        Alt = 2,
        Control = 4,
    }
}