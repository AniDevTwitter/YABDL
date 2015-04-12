using System;
using YABDL.Models.Interfaces;

namespace YABDL.Models.APIs
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

