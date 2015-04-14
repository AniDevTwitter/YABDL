using System;
using System.IO;
using System.Xml.Serialization;

namespace YABDL.Tools.Extensions
{
    public static class XMLSerializableExts
    {
        public static string ToXml<T>(this T theObject)
        {
            using (var stream = new MemoryStream())
            {
                theObject.ToXml(stream);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static void ToXml<T>(this T theObject, Stream stream) 
        {
            new XmlSerializer(typeof(T)).Serialize(stream, theObject);
        }

        public static T FromXml<T>(this Stream XmlStream) 
        {
            return (T) new XmlSerializer(typeof(T)).Deserialize(XmlStream);
        }

        public static T FromXml<T>(this string XmlString) 
        {
            return (T) new XmlSerializer(typeof(T)).Deserialize(new StringReader(XmlString));
        }
    }
}


