using System;

namespace YABDL.Models.Interfaces
{
    public interface IAPIResponse<T>
    {
        bool Success { get;}
        string Message{ get;}
        T Data {get;}
    }
}

