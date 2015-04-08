using System;

namespace YABDL.Models.APIs
{
    public class DanbooruAccess
    {
        private DanbooruPosts posts;
        public DanbooruAccess()
        {
            this.posts = new DanbooruPosts();
        }

        public DanbooruPosts Posts
        {
            get
            {
                return this.posts;
            }
        }
    }
}

