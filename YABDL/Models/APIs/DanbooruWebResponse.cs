using System;
using System.Net;

namespace YABDL.Models.APIs
{
    public class DanbooruWebResponse<T>
    {
        private readonly bool success;
        private readonly string message;
        private readonly T data;

        public DanbooruWebResponse(HttpWebRequest webRequest)
        {
            //todo
        
        }

        public bool Success
        {
            get
            {
                return this.success;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
        }

        public T Data
        {
            get
            {
                return this.data;
            }
        }
    }
}

