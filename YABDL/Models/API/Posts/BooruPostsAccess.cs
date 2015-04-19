using System;
using YABDL.Models.Interfaces;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using YABDL.Models.API.Interfaces;

namespace YABDL.Models.API.Posts
{
    public class BooruPostsAccess : IAPIPostsAccess
    {
        private readonly string extension;

        public BooruPostsAccess(SerializedAs type)
        {
            this.extension = type.GetExtension();
        }

        public IAPIResponse<BooruPost> ShowUnwrapped(IProvider provider, int id)
        {
            var request = new UriBuilder(provider.Url);
            request.Path = provider.Posts + "/" + id + this.extension;
            //Nothing to query beside the id in url so yolo
            return new BooruWebResponse<BooruPost, IProviderPost>(WebRequest.CreateHttp(request.Uri), provider.PostProvider);
        }

        public Task<IAPIResponse<BooruPost>> Show(IProvider provider, int id)
        {
            return new Task<IAPIResponse<BooruPost>>(() => this.ShowUnwrapped(provider, id));
        }

        public IAPIResponse<BooruPosts> ListUnwrapped(IProvider provider, int page = -1, int limit = -1, string tags = "", bool rawtags = false)
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
            return new BooruWebResponse<BooruPosts, IProviderPost>(WebRequest.CreateHttp(request.Uri), provider.PostProvider);
        }
            
        public Task<IAPIResponse<BooruPosts>> List(IProvider provider, int page = -1, int limit = -1, string tags = "", bool rawtags = false)
        {
            return new Task<IAPIResponse<BooruPosts>>(() => this.ListUnwrapped(provider, page, limit, tags, rawtags));
        }
    }
}

