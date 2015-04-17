using YABDL.Models.API.Interfaces;
using YABDL.Models.API.Posts;

namespace YABDL.Models.API
{
    public class DanbooruAccess : IAPIAccess
    {
        private const SerializedAs SerializeAs = SerializedAs.XML; 
        private readonly DanbooruPostsAccess posts;

        public DanbooruAccess()
        {
            this.posts = new DanbooruPostsAccess(SerializedAs.XML);
        }
            
        #region IAPIGlobalAccess implementation

        public IAPIPostsAccess Posts
        {
            get
            {
                return this.posts;
            }
        }

        #endregion
    }
}

