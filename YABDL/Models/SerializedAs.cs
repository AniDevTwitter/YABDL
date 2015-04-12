using System;

namespace YABDL.Models
{
    public enum SerializedAs
    {
        XML,
        // add more if you want
    }

    public static class SerializedAsExts
    {
        public static string GetExtension(this SerializedAs val)
        {
            switch (val)
            {
                case SerializedAs.XML:
                    return ".xml";
                default:
                    throw new NotSupportedException("Follow enum value isn't supported : " + val);
            }
        }
    }
}

