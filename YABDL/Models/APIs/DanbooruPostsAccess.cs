using System;
using YABDL.Models.Interfaces;
using System.Net;
using System.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YABDL.Models.APIs
{
    public class DanbooruPostsAccess : IAPIPostsAccess
    {



        public Task<DanbooruWebResponse<DanbooruPosts>> List(IProvider provider, int page = -1, int limit = -1, string tags = "", bool rawtags = false)
        {
            var request = new UriBuilder(provider.Url);
            // We do not handle username/password/API yet, because it can works without (renember this isn't even functionnal yet)
            var query = HttpUtility.ParseQueryString(request.Query ?? string.Empty);

            if(limit >= 0)
            {
                query[provider.Limit] = limit.ToString();
            }
            if (page >= 0)
            {
                query[provider.Page] = page.ToString();
            }
            if (!string.IsNullOrEmpty(tags))
            {
                query[provider.Tags] = tags;
            }
            if (rawtags)
            {
                query[provider.RawTags] = string.Empty; // this shouldn't crash... WELL I CAN'T CONFIRM IT WILL WORK EITHER
            }
            // We assume it's HTTP but in the future it should handle other protocols too
            var webrequest = WebRequest.CreateHttp(request.Uri);
            return Task.Factory.StartNew(() => new DanbooruWebResponse<DanbooruPosts>(webrequest));
            // Check what happens here, once done, rename this method into something usable elsewhere
        }
    }
}

