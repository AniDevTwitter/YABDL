using System;
using System.IO;

namespace YABDL.Tools.Extensions
{
    public static class StringExts
    {
        public static T ConvertTo<T>(this string value)
        {
            return (T)value.ConvertTo(typeof(T));
        }

        public static object ConvertTo(this string value, Type changeType)
        {
            if (changeType == typeof(Guid))
            {
                return Guid.Parse(value);
            }
            if (string.IsNullOrEmpty(value) && changeType.IsNullable())
            {
                return Activator.CreateInstance(changeType);
            }
            else
            {
                return Convert.ChangeType(value, Nullable.GetUnderlyingType(changeType) ?? changeType);
            }
        }

        /// <summary>
        /// Creates a relative path from one file or folder to another.
        /// </summary>
        /// <param name="fromPath">Contains the directory that defines the start of the relative path.</param>
        /// <param name="toPath">Contains the path that defines the endpoint of the relative path.</param>
        /// <returns>The relative path from the start directory to the end path.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="UriFormatException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static String MakeRelativePath(String fromPath, String toPath)
        {
            if (String.IsNullOrEmpty(fromPath)) throw new ArgumentNullException("fromPath");
            if (String.IsNullOrEmpty(toPath)) throw new ArgumentNullException("toPath");

            Uri fromUri = new Uri(fromPath);
            Uri toUri = new Uri(toPath);

            if (fromUri.Scheme != toUri.Scheme) { return toPath; } // path can't be made relative.

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            String relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (toUri.Scheme.ToUpperInvariant() == "FILE")
            {
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            return relativePath;
        }
    }
}

