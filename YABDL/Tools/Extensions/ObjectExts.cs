using System;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace YABDL.Tools.Extensions
{
    public static class ObjectExts
    {
        public static TReturn Convert<T, TReturn>(this T obj)
        {
            var conversionOperator = typeof(T).GetMethods(BindingFlags.Static | BindingFlags.Public) // Check for public / static methods that can be used to convert
                .Where(m => m.Name == "op_Explicit" || m.Name == "op_Implicit") // These names are the explicit/implicit operators names once compiled
                .Where(m => m.ReturnType == typeof(TReturn)) // Check if the return type is the good one
                .FirstOrDefault(m => m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(T)); // Check if parameters are valid to do the conversion if this type

            if (conversionOperator != null)
            {
                return (TReturn)conversionOperator.Invoke(null, new object[]{ obj });
            }

            throw new ArgumentException("Convert failed as no explicit or implicit operator to cast element has been found");
        }

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

