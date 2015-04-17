using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;

namespace YABDL.Tools.Extensions
{
    public static class XMLSerializableExts
    {


        public static string ToXML<T>(this T theObject)
        {
            using (var stream = new MemoryStream())
            {
                theObject.ToXML(stream);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static void ToXML<T>(this T theObject, Stream stream) 
        {
            new XmlSerializer(typeof(T)).Serialize(stream, theObject);
        }

        public static T FromXML<T>(this Stream XmlStream) 
        {
            return (T) new XmlSerializer(typeof(T)).Deserialize(XmlStream);
        }

        public static T FromXML<T>(this string XmlString) 
        {
            return (T) new XmlSerializer(typeof(T)).Deserialize(new StringReader(XmlString));
        }

        public static XDocument ToXDocument(this Stream stream)
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                return XDocument.Load(reader);    
            }
        } 
    }
}


