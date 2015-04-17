using System;
using YABDL.Models.Interfaces;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using YABDL.Models.API.Interfaces;

namespace YABDL.Models.API.Posts
{
    public class DanbooruPostsAccess : IAPIPostsAccess
    {
        private readonly string extension;

        public DanbooruPostsAccess(SerializedAs type)
        {
            this.extension = type.GetExtension();
        }

        public IAPIResponse<DanbooruPosts> ListDebug(IProvider provider, int page = -1, int limit = -1, string tags = "", bool rawtags = false)
        {
            var request = new UriBuilder(provider.Url);
            request.Path = provider.Posts + this.extension;
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
            request.Query = query.ToString();
            // We assume it's HTTP but in the future it should handle other protocols too
            var dbg = new DanbooruWebResponse<DanbooruPosts, IProviderPosts>(WebRequest.CreateHttp(request.Uri), provider.PostsProvider);
            return dbg;
        }


        public Task<IAPIResponse<DanbooruPosts>> List(IProvider provider, int page = -1, int limit = -1, string tags = "", bool rawtags = false)
        {
            var request = new UriBuilder(provider.Url);
            request.Path = provider.Posts + this.extension;
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
            request.Query = query.ToString();
            // We assume it's HTTP but in the future it should handle other protocols too
            return new Task<IAPIResponse<DanbooruPosts>>(() => new DanbooruWebResponse<DanbooruPosts, IProviderPosts>(WebRequest.CreateHttp(request.Uri), provider.PostsProvider));
        }
    }
}

