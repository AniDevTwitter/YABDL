using System;
using System.Linq.Expressions;
using System.Diagnostics;

namespace YABDL.Tools.Extensions
{
    public static class ObjectExts
    {
        public static string ConvertToString(this object item)
        {
            return System.Convert.ToString(item);
        }

        public static string NameOf<TSource, TProp>(this TSource source, Expression<Func<TSource, TProp>> expression)
        {
            return ((MemberExpression)expression.Body).Member.Name;
        }

        public static T Pipe<T>(this T item, Action<T> action)
        {
            action(item);
            return item;
        }

        [DebuggerStepThrough]
        public static bool ReferenceEquals<T, U>(this T first, U second)
            where T : class
            where U : class
        {
            return object.ReferenceEquals(first, second);
        }

        [DebuggerStepThrough]
        public static T ThrowIfNull<T>(this T value, string variableName)
        {
            if (object.ReferenceEquals(value, null))
            {
                throw new NullReferenceException(string.Format("Value is Null: {0}", variableName));
            }

            return value;
        }

        [DebuggerStepThrough]
        public static T ThrowIfNull<T>(this T value)
        {
            return value.ThrowIfNull(string.Empty);
        }
    }
}

