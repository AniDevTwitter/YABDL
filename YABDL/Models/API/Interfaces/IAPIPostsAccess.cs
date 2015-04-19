using System;
using System.Threading.Tasks;
using YABDL.Models.API;
using YABDL.Models.Interfaces;
using YABDL.Models.API.Posts;

namespace YABDL.Models.API.Interfaces
{
    public interface IAPIPostsAccess
    {
        IAPIResponse<BooruPosts> List(IProvider provider, int page = -1, int limit = -1, string tags = "", bool rawtags = false);
        IAPIResponse<BooruPost> Show(IProvider provider, int id);
        Task<IAPIResponse<BooruPosts>> ListAsync(IProvider provider, int page = -1, int limit = -1, string tags = "", bool rawtags = false);
        Task<IAPIResponse<BooruPost>> ShowAsync(IProvider provider, int id);

    }
}

