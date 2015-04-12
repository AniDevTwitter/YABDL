using System;
using System.Threading.Tasks;
using YABDL.Models.APIs;

namespace YABDL.Models.Interfaces
{
    public interface IAPIPostsAccess
    {
        Task<IAPIResponse<DanbooruPosts>> List(IProvider provider, int page = -1, int limit = -1, string tags = "", bool rawtags = false);
    }
}

