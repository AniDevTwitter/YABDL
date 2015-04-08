using System;

namespace YABDL.Models.Interfaces
{
    public interface IProvider
    {
        string Name { get; set; }

        string Url { get; set; }


        // todo probably IEnumerable of image urls
    }
}

