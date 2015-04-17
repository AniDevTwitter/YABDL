using System;

namespace YABDL.Models.API.Interfaces
{
    public interface IAPIAccess
    {
        IAPIPostsAccess Posts { get; }
    }
}

