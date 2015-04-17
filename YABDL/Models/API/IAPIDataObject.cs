using System;

namespace YABDL.APIs.Interfaces
{
    public interface IAPIDataObject
    {
        void FromXml(string xml);
        string ToXml();
    }
}

