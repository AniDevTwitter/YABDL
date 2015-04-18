using YABDL.Models.API.Interfaces;
using YABDL.Models.API.Posts;

namespace YABDL.Models.API
{
    public class BooruAccess : IAPIAccess
    {
        private const SerializedAs SerializeAs = SerializedAs.XML; 
        private readonly BooruPostsAccess posts;

        public BooruAccess()
        {
            this.posts = new BooruPostsAccess(SerializedAs.XML);
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

