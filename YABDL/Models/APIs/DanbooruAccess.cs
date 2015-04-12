using System;
using YABDL.Models.Interfaces;

namespace YABDL.Models.APIs
{
    public class DanbooruAccess : IAPIGlobalAccess
    {
        private readonly DanbooruPostsAccess posts;

        public DanbooruAccess()
        {
            this.posts = new DanbooruPostsAccess();
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

