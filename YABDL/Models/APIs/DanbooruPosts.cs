using System;
using YABDL.Models.Interfaces;
using System.Net;
using System.Web;
using YABDL.Tools.Extenstions;

namespace YABDL.Models.APIs
{
    public class DanbooruPosts
    {
        // These constants are aimed to be stored in a future conf file, thus only one API access would be necesary for multiple differents boorus rest API
        private const string Limit = @"limit";
        private const string Tags = @"tags";
        private const string RawTags = @"raw";

        public DanbooruPosts()
        {

        }
           

        public void List(IProvider provider, int limit = -1, string tags = "", bool rawtags = false)
        {
            var request = new UriBuilder(provider.Url);
            // We do not handle username/password/API yet, because it can works without (renember this isn't even functionnal yet)
            var query = HttpUtility.ParseQueryString(request.Query ?? string.Empty);
            if(limit >= 0)
            {
                query[DanbooruPosts.Limit] = limit.ToString();
            }
            if (!string.IsNullOrEmpty(tags))
            {
                query[DanbooruPosts.Tags] = tags;
            }
            if (rawtags)
            {
                query[DanbooruPosts.RawTags] = string.Empty; // this shouldn't crash... WELL I CAN'T CONFIRM IT WILL WORK EITHER
            }
            // We assume it's HTTP but in the future it should handle other protocols too
            var response = WebRequest.CreateHttp(request.Uri);
            response.ToString();
            // Check what happens here, once done, rename this method into something usable elsewhere
        }
    }
}

