using System;
using System.Threading.Tasks;
using YABDL.Models.API;
using YABDL.Models.Interfaces;
using YABDL.Models.API.Posts;

namespace YABDL.Models.API.Interfaces
{
    public interface IAPIPostsAccess
    {
        Task<IAPIResponse<DanbooruPosts>> List(IProvider provider, int page = -1, int limit = -1, string tags = "", bool rawtags = false);
    }
}

