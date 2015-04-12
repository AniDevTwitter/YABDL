using System;
using System.Collections.Specialized;
using System.Web;
using System.Linq;
using MoreLinq;

namespace YABDL.Tools.Extenstions
{
    public static class NameValueCollectionExts
    {
        public static string ToQueryString(this NameValueCollection nvc)
        {
            return "?" + string.Join("&", nvc.AllKeys.Select(x => string.Format("{0}={1}", HttpUtility.UrlEncode(x), HttpUtility.UrlEncode(nvc.GetValues(x).Single()))));
        }
    }
}

