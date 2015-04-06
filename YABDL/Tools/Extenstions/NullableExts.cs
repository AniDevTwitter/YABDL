using System;
using System.Diagnostics;

namespace YABDL.Tools.Extenstions
{
    public static class NullableExts
    {
        [DebuggerStepThrough]
        public static T ThrowIfNull<T>(this T? value) where T : struct
        {
            return value.ThrowIfNull(string.Empty);
        }

        [DebuggerStepThrough]
        public static T ThrowIfNull<T>(this T? value, string message) where T : struct
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException(message);
            }
            return value.Value;
        }
    }
}

