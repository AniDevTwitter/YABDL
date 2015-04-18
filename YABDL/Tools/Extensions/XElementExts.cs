using System;
using System.Xml.Linq;

namespace YABDL.Tools.Extensions
{
    public static class XElementExts
    {
        public static TReturn? NullIfEmpty<TReturn>(this XElement item)
            where TReturn : struct
        {
            if ((item == null) || (item.IsEmpty))
            {
                return default (TReturn?);
            }
            return item.Convert<XElement, TReturn?>();
        }
    }
}

