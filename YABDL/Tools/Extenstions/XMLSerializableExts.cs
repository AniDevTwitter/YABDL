using System;
using System.IO;
using System.Xml.Serialization;

namespace YABDL.Tools.Extenstions
{
    public static class XMLSerializableExts
    {
        public static void ToXML<T>(this T theObject, Stream stream) 
        {
            new XmlSerializer(theObject.GetType()).Serialize(stream, theObject);
        }

        public static T FromXML<T>(this Stream XmlStream) 
        {
            return (T) new XmlSerializer(typeof(T)).Deserialize(XmlStream);
        }

        public static T FromXML<T>(this string XmlString) 
        {
            return (T) new XmlSerializer(typeof(T)).Deserialize(new StringReader(XmlString));
        }
    }
}


