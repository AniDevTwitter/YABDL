using System;
using System.IO;

namespace YABDL.Models.API.Interfaces
{
    public interface IAPIDataObject<T>
    {
        void DeserializeFromXML(Stream xml, T restMetatadatasProvider);
        Stream SerializeToXML(T restMetatadatasProvider);
    }
}

